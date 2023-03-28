using Microsoft.AspNetCore.Mvc;
using MyCRM.Interface.Service;
using MyCRM.Models;
using Newtonsoft.Json;

namespace MyCRM.Controllers
{
    public class ChatController : Controller
    {
        private readonly IServiceManager _service;

        public ChatController(IServiceManager service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.User.GetAll());
        }

        public JsonResult GetChat(string senderId, string recipientId)
        {
            var chats = _service.Chat.GetChatMessages(senderId, recipientId);
            return Json(JsonConvert.SerializeObject(chats));
        }

        public JsonResult SendMessage(string senderId, string recipientId, string messageText)
        {
            _service.Chat.SendMessage(senderId, recipientId, messageText);
            return Json("Success");
        }
    }
}
