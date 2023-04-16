using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.Migrations
{
    public partial class addChatMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ChatMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "ChatMessages",
                columns: new[] { "Id", "ChatId", "CreatedAt", "Message", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 16, 16, 14, 37, 213, DateTimeKind.Utc).AddTicks(4695), "Hi, dit is een test bericht, ik wil even testen wat er gebeurd zodra dit bericht vrij lang word :o", "c2e0f6b4-957d-4468-89cb-87f6ec7c1994" },
                    { 2, 1, new DateTime(2023, 4, 16, 16, 14, 37, 213, DateTimeKind.Utc).AddTicks(4697), "Waaa echt??? omgg nu moeten we de chat opvullen voor een scrollbar!", "253abbf5-2614-4fd8-a82c-c32f2b043900" },
                    { 3, 1, new DateTime(2023, 4, 16, 16, 14, 37, 213, DateTimeKind.Utc).AddTicks(4698), "Hallo??? :o", "253abbf5-2614-4fd8-a82c-c32f2b043900" },
                    { 4, 1, new DateTime(2023, 4, 16, 16, 14, 37, 213, DateTimeKind.Utc).AddTicks(4699), "Sorry voor de late reactie, of was dit ook een test?", "c2e0f6b4-957d-4468-89cb-87f6ec7c1994" },
                    { 5, 1, new DateTime(2023, 4, 16, 16, 14, 37, 213, DateTimeKind.Utc).AddTicks(4700), "Ohhh, I see I see :o waaaaaaaaaaaaaaaaaaaaa", "253abbf5-2614-4fd8-a82c-c32f2b043900" }
                });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Url", "UserId" },
                values: new object[] { "27fc225c8d", "c2e0f6b4-957d-4468-89cb-87f6ec7c1994" });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Url", "UserId" },
                values: new object[] { "fe097c6d99", "c2e0f6b4-957d-4468-89cb-87f6ec7c1994" });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Url", "UserId" },
                values: new object[] { "c5cb2c5c2a", "c2e0f6b4-957d-4468-89cb-87f6ec7c1994" });
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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ChatMessages");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Url", "UserId" },
                values: new object[] { "fe25be987d", "e957327f-7b1d-4c97-bfca-b3ae57506a69" });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Url", "UserId" },
                values: new object[] { "a24d48ab3a", "e957327f-7b1d-4c97-bfca-b3ae57506a69" });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Url", "UserId" },
                values: new object[] { "54eb213de0", "e957327f-7b1d-4c97-bfca-b3ae57506a69" });
        }
    }
}
