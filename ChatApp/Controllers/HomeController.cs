using ChatApp.Areas.Identity.Data;
using ChatApp.Data;
using ChatApp.Hubs;
using ChatApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Diagnostics;
using System.Security.Claims;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
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
            if(_userManager.GetUserId(HttpContext.User) != null)
            {
                var Chat = _context.Chats.Where(c => c.Url == id).FirstOrDefault();
                if (Chat != null)
                {
                    //save title in viewbag
                    ViewBag.Title = Chat.Title;
                    return View();
                }
                //redirect to home screen in case chat does not exist (Maybe add/provide error?)
                return Redirect("/");
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