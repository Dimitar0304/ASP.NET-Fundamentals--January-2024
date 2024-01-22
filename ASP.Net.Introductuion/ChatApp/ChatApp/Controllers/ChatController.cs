using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>>
            messages = new List<KeyValuePair<string, string>>();
        [HttpGet]
        public IActionResult Show()
        {
            if (messages.Count < 1)
            {

                return View(new ChatViewModel());
            }
            var chat = new ChatViewModel()
            {
                Messages=messages.Select(m=>new MessageViewModel()
                {
                    Message = m.Key,
                    Sender = m.Value
                })
                .ToList()

            };
            return View(chat);
        }
        [HttpPost]
        public IActionResult Send(ChatViewModel chatModel)
        {
            var message = chatModel.CurrentMessage;
            messages.Add(new KeyValuePair<string, string>(message.Sender,message.Message));
            return RedirectToAction("Show");
        }
    }
}
