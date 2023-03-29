using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Interface.Service;
using MyCRM.Models;
using Newtonsoft.Json;

namespace MyCRM.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IServiceManager _service;

        public ChatController(IServiceManager service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin,IndexChat")]
        public IActionResult Index()
        {
            return View(_service.User.GetAll());
        }

        [Authorize(Roles = "Admin,GetChatChat")]
        public JsonResult GetChat(string senderId, string recipientId)
        {
            var chats = _service.Chat.GetChatMessages(senderId, recipientId);
            return Json(JsonConvert.SerializeObject(chats));
        }

        [Authorize(Roles = "Admin,SendMessageChat")]
        public JsonResult SendMessage(string senderId, string recipientId, string messageText)
        {
            _service.Chat.SendMessage(senderId, recipientId, messageText);
            return Json(DateTime.Now.ToShortTimeString() + ", " + DateTime.Now.ToShortDateString());
        }
    }
}
