using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> Messages =
            new List<KeyValuePair<string, string>>();

        public IActionResult Show()
        {
            if (Messages.Count() < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = Messages
                    .Select(m => new MessageViewModel()
                    {
                        Sender = m.Key,
                        MessageText = m.Value
                    })
                    .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;

            Messages.Add(new KeyValuePair<string, string>
                (newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
