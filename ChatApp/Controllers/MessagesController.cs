﻿using ChatApp.Areas.Identity.Data;
using ChatApp.Data;
using ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public MessagesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Get all messages from a chat
        /// </summary>
        /// <param name="url"></param>
        /// <returns>all chatmessages</returns>
        //GET: api/Messages/{url}
        [HttpGet("{url}")]
        public async Task<IActionResult> GetMessages(string url)
        {
            var username = _userManager.GetUserName(User);
            var chat = _context.Chats.FirstOrDefault(c => c.Url == url);
            if (chat == null)
            {
                return NotFound();
            }

            var messages = await _context.ChatMessages
            .Include(m => m.ApplicationUser)
            .Where(m => m.ChatId == chat.Id)
            .ToListAsync();

            var userIds = messages.Select(x => x.UserId).ToArray();
            var users = await _context.Users
                .Where(x => userIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x);

            var viewModels = messages.Select(x => new MessageViewModel
            {
                Message = x.Message,
                CreatedAt = x.CreatedAt,
                Username = (users.GetValueOrDefault(x.UserId)?.UserName == username && username != null) ? null : users.GetValueOrDefault(x.UserId)?.UserName,
            });

            return Ok(viewModels);
        }
    }
}
