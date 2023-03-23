using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatsController : Controller
    {
        //GET: Chats
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }
    }
}
