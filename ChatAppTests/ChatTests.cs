using Moq;
using Moq.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ChatApp.Areas.Identity.Data;
using ChatApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Data;
using System.Security.Claims;
using ChatAppTests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

[TestFixture]
public class ChatsControllerTests
{
    private ChatsController _controller;
    private Mock<ITempDataDictionary> _tempData;
    private Mock<ApplicationDbContext> _mockDbContext;
    private Mock<UserManager<IdentityUser>> _mockUserManager;
    private RoleManager<IdentityRole> _roleManagerMock;
    private Mock<ILogger<ChatsController>> _mockLogger;

    [SetUp]
    public void Setup()
    {
        // Initialize mock objects
        _mockDbContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());

        var store = new Mock<IUserStore<IdentityUser>>();
        _mockUserManager = new Mock<UserManager<IdentityUser>>(
            store.Object, null!, null!, null!, null!, null!, null!, null!, null!);
        SetupUser();

        var roleStore = new Mock<IRoleStore<IdentityRole>>();
        _roleManagerMock = new RoleManager<IdentityRole>(roleStore.Object, null!, null!, null!, null!);

        _mockLogger = new Mock<ILogger<ChatsController>>();
        _tempData = new Mock<ITempDataDictionary>();
        _controller = new ChatsController(_mockDbContext.Object, _mockUserManager.Object, _roleManagerMock, _mockLogger.Object)
        {
            TempData = _tempData.Object // Set the controller's TempData to the mocked TempData
        };
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal()
            }
        };
    }

    [Test]
    public async Task CreateValidChat_CreatesChat()
    {
        // Arrange
        var chat = ChatBuilder.BuildValidChat();

        //Act
        var result = await _controller.Create(chat);
        var redirectResult = result as RedirectResult;
        var redirectUrl = redirectResult?.Url;

        //Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<RedirectResult>(result);
        Assert.AreEqual("/", redirectUrl);

        // Verify if TempData["success"] has been set
        _tempData.VerifySet(tempData => tempData["success"] = "You've created your chat!", Times.Once);
    }

    [Test]
    public async Task DeleteValidChat_DeletesChat()
    {
        // Arrange
        var chats = ChatBuilder.BuildValidChatWithMessages(); // Mock data initialization

        var chatIdToDelete = 1;
        var chatToDelete = chats.FirstOrDefault(c => c.Id == chatIdToDelete);

        _mockDbContext.Setup(x => x.Chats.FindAsync(chatIdToDelete)).ReturnsAsync(chatToDelete);

        //Act
        var result = await _controller.Delete(chatIdToDelete);
        var redirectResult = result as RedirectResult;
        var redirectUrl = redirectResult?.Url;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<RedirectResult>(result);
        Assert.AreEqual("/", redirectUrl);

        // Verify if TempData["success"] has been set
        _tempData.VerifySet(tempData => tempData["success"] = "Chat successfully deleted!", Times.Once);
    }

    [Test]
    public async Task DeleteInvalidChat_ThrowsError()
    {
        // Arrange
        var chats = ChatBuilder.BuildValidChatWithMessages(); // Mock data initialization

        _mockDbContext.Setup(x => x.Chats).ReturnsDbSet(ChatBuilder.BuildValidChatWithMessages());

        //Act
        var result = await _controller.Delete(0);
        var redirectResult = result as RedirectResult;
        var redirectUrl = redirectResult?.Url;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<RedirectResult>(result);
        Assert.That(redirectUrl, Is.EqualTo("/"));

        // Verify if TempData["success"] has been set
        _tempData.VerifySet(tempData => tempData["error"] = "You do not have the right permissions to perform this action!", Times.Once);
    }

    public void SetupUser()
    {
        // Mocking the user
        var user = new ApplicationUser
        {
            Id = "userId1", // Set the ID as needed
            UserName = "user1" // Set the username as needed
                               // Add other properties as needed
        };
        var userClaims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        // Add other claims as needed
    };
        var userIdentity = new ClaimsIdentity(userClaims, "mock");
        var claimsPrincipal = new ClaimsPrincipal(userIdentity);

        _mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
    }
}