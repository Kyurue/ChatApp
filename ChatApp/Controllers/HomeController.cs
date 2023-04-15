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
            return View(await _context.Chats.OrderByDescending(i => i.Id).ToListAsync());
        }

        //GET: Home/Chat/{Url}
        public IActionResult Chat(string? id)
        {
            var Chat = _context.Chats.Where(c => c.Url == id).FirstOrDefault();
            if (Chat != null)
            {
                ViewBag.Title = Chat.Title;
                //return chatmessages
                return View();
            }
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}