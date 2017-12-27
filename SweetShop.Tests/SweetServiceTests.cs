using System;

using Microsoft.AspNet.Identity;

using Moq;
using Xunit;

namespace SweetShop.Tests
{
    public class SweetServiceTests
    {
        [Theory]
        [InlineData("SweetTooth", 100)]
        [InlineData("CookieMonster", 1)]
        public async void CorrectNumberOfGummyBearsForUsersRoleIsReturned(string roleName, int expectedNumberOfGummyBearsReturned)
        {
            // Arrange
            const string SWEET_TOOTH_ROLENAME = "SweetTooth";

            var userId = Guid.NewGuid().ToString();

            var mockUserStore = new Mock<IUserStore<ApplicationUser>>();
            var mockUserRoleStore = mockUserStore.As<IUserRoleStore<ApplicationUser>>();
            var userManager = new UserManager<ApplicationUser>(mockUserStore.Object);

            mockUserStore.Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(new ApplicationUser()
                {
                    UserName = "test@email.com"
                });

            mockUserRoleStore.Setup(x => x.IsInRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(roleName.Equals(SWEET_TOOTH_ROLENAME, StringComparison.OrdinalIgnoreCase));

            var objectUnderTest = new SweetService(userManager);

            // Act
            var actualResult = await objectUnderTest.NumberOfGummyBearsForUser(userId);

            // Assert
            Assert.Equal(expectedNumberOfGummyBearsReturned, actualResult);
        }
    }
}
