"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

var currentdate = new Date();
var datetime = currentdate.getHours() + ":"
    + currentdate.getMinutes() + ', '
    + currentdate.getDate() + '.'
    + (currentdate.getMonth() + 1) + '.'
    + currentdate.getFullYear();

connection.on("ReceiveMessage", function (sender, recipient, message) {

    if (sender == $('#sender').val() && recipient == $('#recipient').val()) {
        rightMessage(datetime, message);
    }
    if (recipient == $('#sender').val() && sender == $('#recipient').val()) {
        leftMessage(datetime, message);
    }
    $('#chatPanel').scrollTop($('#chatPanel')[0].scrollHeight);
});

connection.start().then(function () {}).catch(function (err) {
    return console.error(err.toString());
});

function getChatWithUser(recipientId, recipientName, sender) {
    $('#sender').val(sender);
    $('#recipient').val(recipientId);
    $('#selectedChat').text(recipientName);

    $('#chatMessageContainer').empty();
    var _url = 'Chat/GetChat';
    $.post(_url,
        {
            senderId: $('#sender').val(),
            recipientId: $('#recipient').val()
        },
        function (data, status) {
            var json = $.parseJSON(data);
            $.each(json, function (key, obj) {
                if (obj.Sender == $('#sender').val()) {
                    rightMessage(obj.Created, obj.Message);
                }
                else {
                    leftMessage(obj.Created, obj.Message);
                }
                $('#chatPanel').scrollTop($('#chatPanel')[0].scrollHeight);
                
            });
            $('#sendBtn').removeAttr('hidden');
        }
    );
}

function sendMessage() {
    connection.invoke("SendMessage", $('#sender').val(), $('#recipient').val(), $('#chatMessage').val()).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

    var _url = 'Chat/SendMessage';
    $.post(_url,
        {
            senderId: $('#sender').val(),
            recipientId: $('#recipient').val(),
            messageText: $('#chatMessage').val()
        },
        function (data, status) {
            rightMessage(data, $('#chatMessage').val());
            $('#chatPanel').scrollTop($('#chatPanel')[0].scrollHeight);
            $('#chatMessage').val('');
        }
    );
}


function rightMessage(created, message) {
    $('#chatMessageContainer').append('<li class="clearfix"><div class="message-data text-right"><span class="message-data-time">' + created + '</span></div><div class="message other-message float-right">' + message + ' </div></li>');
}

function leftMessage(created, message) {
    $('#chatMessageContainer').append('<li class="clearfix"><div class="message-data"><span class="message-data-time">' + created + '</span></div><div class="message my-message">' + message + ' </div></li>');
}