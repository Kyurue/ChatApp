using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.AspNetCore.Identity;
using ChatApp.Controllers;

namespace ChatAppTests
{
    internal class RoleTests
    {
        private RolesController _controller;
        private Mock<RoleManager<IdentityRole>> _mockRoleManager;

        [SetUp]
        public void Setup()
        {
            // Mock RoleManager
            var roleStore = new Mock<IRoleStore<IdentityRole>>();
            _mockRoleManager = new Mock<RoleManager<IdentityRole>>(roleStore.Object, null!, null!, null!, null!);

            _controller = new RolesController(_mockRoleManager.Object);
        }

        [Test]
        public async Task AddRole_ReturnsRedirectToAction()
        {
            // Arrange
            var roleName = "TestRole";

            // Act
            var result = await _controller.AddRole(roleName) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task AddRole_CreatesRoleWhenRoleNameIsNotNull()
        {
            // Arrange
            var roleName = "TestRole";

            // Act
            await _controller.AddRole(roleName);

            // Assert
            _mockRoleManager.Verify(m => m.CreateAsync(It.Is<IdentityRole>(r => r.Name == roleName.Trim())), Times.Once);
        }

        [Test]
        public async Task AddRole_DoesNotCreateRoleWhenRoleNameIsNull()
        {
            // Arrange
            string roleName = null!;

            // Act
            await _controller.AddRole(roleName);

            // Assert
            _mockRoleManager.Verify(m => m.CreateAsync(It.IsAny<IdentityRole>()), Times.Never);
        }
    }
}
