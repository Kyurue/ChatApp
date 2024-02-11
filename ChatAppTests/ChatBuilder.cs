using ChatApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatAppTests
{
    internal class ChatBuilder
    {
        public static List<ChatApp.Data.Chat> BuildValidChatWithMessages()
        {
            return new List<ChatApp.Data.Chat>
            {
                new ChatApp.Data.Chat
                {
                    Id = 1,
                    UserId = "userId1",
                    Title = "Test Chat 1",
                    Description = "This is a test chat",
                    Url = "khkqwnkljn",
                    LoggedInOnly = false,
                    ChatMessages = new List<ChatApp.Data.ChatMessage>
                    {
                        new ChatApp.Data.ChatMessage
                        {
                            Id = 1,
                            UserId = "userId1",
                            ChatId = 1,
                            Message = "Hello, World!",
                            CreatedAt = DateTime.UtcNow
                        },
                        new ChatApp.Data.ChatMessage
                        {
                            Id = 2,
                            UserId = "userId2",
                            ChatId = 2,
                            Message = "Hello!",
                            CreatedAt = DateTime.UtcNow
                        },
                        new ChatApp.Data.ChatMessage
                        {
                            Id = 3,
                            UserId = "userId3",
                            ChatId = 3,
                            Message = "Hi, World!",
                            CreatedAt = DateTime.UtcNow
                        }
                    }
                }
            };
        }

        public static Chat BuildValidChat()
        {
            return new Chat
            {
                Id = 1,
                UserId = "userId1",
                Title = "Test Chat 1",
                Description = "This is a test chat",
                Url = "khkqwnkljn",
                LoggedInOnly = false,
            };
        }
    }
}