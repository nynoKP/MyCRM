using MyCRM.Interface.Repository;
using MyCRM.Models;
using MyCRM.ViewModels;

namespace MyCRM.Services
{
    public class ChatService
    {
        public readonly IRepositoryManager _repository;
        public ChatService(IRepositoryManager repositoryManager)
        {
            _repository = repositoryManager;
        }

        public List<ChatMessageViewModel> GetChatMessages(string senderId, string resipientId)
        {
            var sender = _repository.Users.GetById(senderId);
            var recipient = _repository.Users.GetById(resipientId);
            return _repository.Chat.GetChatMessages(sender, recipient)
                .Select(c => new ChatMessageViewModel() { Sender = c.Sender?.Id, Recipient = c.Recipient?.Id, Message = c.Message, Created = c.Created.Value.ToShortTimeString() + ", " + c.Created.Value.ToShortDateString() }).ToList();
        }

        public void SendMessage(string senderId, string recipentId, string messageText)
        {
            _repository.Chat.Create(new ChatMessage()
            {
                Sender = _repository.Users.GetById(senderId),
                Recipient = _repository.Users.GetById(recipentId),
                Message = messageText,
                Created = DateTime.Now
            });
            _repository.Save();
        }
    }
}
