using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.Migrations
{
    public partial class seedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Description", "LoggedInOnly", "Title", "Url", "UserId" },
                values: new object[] { 1, "Dit is een chat om te testen", false, "TestChat", "3541b070c0", "3dede8f3-0bf4-42af-83fa-f3a52f42b70f" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Description", "LoggedInOnly", "Title", "Url", "UserId" },
                values: new object[] { 2, "Dit is een extra chatje om te testen", false, "TestChatje", "a69bdcb254", "3dede8f3-0bf4-42af-83fa-f3a52f42b70f" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Description", "LoggedInOnly", "Title", "Url", "UserId" },
                values: new object[] { 3, "Dit is een extra chatttt om te testen", false, "TestChatt", "0fc718dc40", "3dede8f3-0bf4-42af-83fa-f3a52f42b70f" });

            migrationBuilder.InsertData(
                table: "ChatMessages",
                columns: new[] { "Id", "ChatId", "CreatedAt", "Message", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 24, 21, 47, 50, 617, DateTimeKind.Utc).AddTicks(4965), "Hi, dit is een test bericht, ik wil even testen wat er gebeurd zodra dit bericht vrij lang word :o", "3dede8f3-0bf4-42af-83fa-f3a52f42b70f" },
                    { 2, 1, new DateTime(2023, 4, 24, 21, 47, 50, 617, DateTimeKind.Utc).AddTicks(4966), "Waaa echt??? omgg nu moeten we de chat opvullen voor een scrollbar!", "8eb52ad0-6358-4bba-b6f8-b655302aa4fd" },
                    { 3, 1, new DateTime(2023, 4, 24, 21, 47, 50, 617, DateTimeKind.Utc).AddTicks(4967), "Hallo??? :o", "8eb52ad0-6358-4bba-b6f8-b655302aa4fd" },
                    { 4, 1, new DateTime(2023, 4, 24, 21, 47, 50, 617, DateTimeKind.Utc).AddTicks(4967), "Sorry voor de late reactie, of was dit ook een test?", "3dede8f3-0bf4-42af-83fa-f3a52f42b70f" },
                    { 5, 1, new DateTime(2023, 4, 24, 21, 47, 50, 617, DateTimeKind.Utc).AddTicks(4968), "Ohhh, I see I see :o waaaaaaaaaaaaaaaaaaaaa", "8eb52ad0-6358-4bba-b6f8-b655302aa4fd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ChatMessages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
