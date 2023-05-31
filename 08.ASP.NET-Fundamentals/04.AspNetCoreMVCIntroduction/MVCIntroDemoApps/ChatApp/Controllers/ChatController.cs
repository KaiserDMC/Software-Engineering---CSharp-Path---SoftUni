using ChatApp.ViewModels.Chat;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> _messages = new List<KeyValuePair<string, string>>();

        [HttpGet]
        public IActionResult Show()
        {
            if (_messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatViewModel = new ChatViewModel()
            {
                AllMessages = _messages
                    .Select(m=>new MessageViewModel()
                    {
                        Sender = m.Key,
                        MessageText = m.Value
                    })
                    .ToHashSet()
            };

            return View(chatViewModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chatViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Show");
            }

            _messages.Add(new KeyValuePair<string, string>(chatViewModel.CurrentMessage.Sender, chatViewModel.CurrentMessage.MessageText));

            return this.RedirectToAction("Show");
        }
    }
}
