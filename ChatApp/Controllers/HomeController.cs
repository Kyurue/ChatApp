using ChatApp.Areas.Identity.Data;
using ChatApp.Hubs;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Diagnostics;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //create list with chats
            return View(await _context.Chats.OrderByDescending(i => i.Id).ToListAsync());
        }

        //GET: Home/Chat/{Url}
        public async Task<IActionResult> Chat(string? id)
        {
            //Check if chat exists based on url
            var Chat = _context.Chats.Where(c => c.Url == id).FirstOrDefault();
            if (Chat != null)
            {
                //save title in viewbag
                ViewBag.Title = Chat.Title;

                //Need to add chatmessages in the return view and show them in the view. 
                return View(await _context.ChatMessages.Where(m => m.ChatId == Chat.Id).ToListAsync());
            }
            //redirect to home screen in case chat does not exist (Maybe add/provide error?)
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}