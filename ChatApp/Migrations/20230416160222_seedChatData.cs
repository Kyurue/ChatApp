using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatApp.Migrations
{
    public partial class seedChatData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Description", "LoggedInOnly", "Title", "Url", "UserId" },
                values: new object[] { 1, "Dit is een chat om te testen", false, "TestChat", "fe25be987d", "c2e0f6b4-957d-4468-89cb-87f6ec7c1994" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Description", "LoggedInOnly", "Title", "Url", "UserId" },
                values: new object[] { 2, "Dit is een extra chatje om te testen", false, "TestChatje", "a24d48ab3a", "c2e0f6b4-957d-4468-89cb-87f6ec7c1994" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Description", "LoggedInOnly", "Title", "Url", "UserId" },
                values: new object[] { 3, "Dit is een extra chatttt om te testen", false, "TestChatt", "54eb213de0", "c2e0f6b4-957d-4468-89cb-87f6ec7c1994" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
