using ChatApp.Areas.Identity.Data;
using ChatApp.Data;
using ChatApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        /// <summary>
        /// Home page
        /// </summary>
        /// <returns>The home page view</returns>
        public IActionResult Index()
        {
            //create list with chats
            ViewBag.UserId = _userManager.GetUserId(User);
            return View( _context.Chats.OrderByDescending(i => i.Id).ToList());
        }

        /// <summary>
        /// Chat page
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Chat view</returns>
        //GET: Home/Chat/{Url}
        public IActionResult Chat(string? id)
        {
                //Check if chat exists based on url
                var Chat = _context.Chats.Where(c => c.Url == id).FirstOrDefault();
                if (Chat != null)
                {
                    if (_userManager.GetUserId(User) == null)
                    {
                        ViewBag.NoUser = true;
                    } else
                    {
                        ViewBag.NoUser = false;
                    }
                    //save title in viewbag
                    ViewBag.Title = Chat.Title;
                    return View();
                }
                //redirect to home screen in case chat does not exist (Maybe add/provide error?)
                TempData["error"] = "Chat does not exist!";
                return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}