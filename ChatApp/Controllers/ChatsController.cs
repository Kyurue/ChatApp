using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatApp.Areas.Identity.Data;
using ChatApp.Data;
using Microsoft.AspNetCore.Identity;

namespace ChatApp.Controllers
{
    public class ChatsController : Controller
    {
        private static Random random = new Random();
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ChatsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Chats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Title,Description,Url,LoggedInOnly")] Chat chat)
        {
            chat.Url = RandomString(10);
            chat.UserId = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                _context.Add(chat);
                await _context.SaveChangesAsync();
                TempData["success"] = "You've created your chat!";
                return Redirect("/");
            }
            return View(chat);
        }

        // POST: Chats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //get userrole of logged in user as string
            var user = await _userManager.GetUserAsync(User);
            var userRole = await _userManager.GetRolesAsync(user);
            var userRoleString = userRole[0].ToString();
            if (_userManager.GetUserId(User) != null && userRoleString == "Admin" || userRoleString == "Moderator")
            {
                if (_context.Chats == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Chats'  is null.");
                }
                var chat = await _context.Chats.FindAsync(id);
                if (chat != null)
                {
                    _context.Chats.Remove(chat);
                }

                await _context.SaveChangesAsync();
                TempData["success"] = "Chat deleted!";
                return Redirect("/");
            }
            TempData["error"] = "You do not have the right role to perform this action!";
            return Redirect("/");
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
