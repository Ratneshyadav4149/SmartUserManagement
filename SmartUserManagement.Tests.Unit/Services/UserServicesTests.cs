using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SmartUserManagement.Business.Services;
using SmartUserManagement.Domain.Interfaces;
using SmartUserManagement.Domain.Models;

namespace SmartUserManagement.Tests.Unit.Services
{
    public class UserServicesTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly UserServices _userServices;

        public UserServicesTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _userServices = new UserServices(_mockRepository.Object);
        }

        [Fact]

        public void CreateUser_shouldAddUser_whenValidUser()
        {
            // Arrange
            var users = new List<User>();
            _mockRepository.Setup(x => x.GetAllUsers()).Returns(users);

            var user = new User()
            {
                Name = "Ram"
            };
            // Act
            _userServices.CreateUser(user);
            _mockRepository.Verify(x => x.AddUser(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void CreateUser_ShouldThrowException_WhenNameIsEmpty()
        {
            // Arrange

            var user = new User
            {
                Name = ""
            };

            // Act & Assert

            var exception = Assert.Throws<Exception>(() =>
                _userServices.CreateUser(user));

            Assert.Equal(
                "User name is required",
                exception.Message);
        }

        [Fact]
        public void CreateUser_ShouldThrowException_WhenUserAlreadyExists()
        {
            // Arrange

            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Ram"
                }
            };

            _mockRepository
                .Setup(x => x.GetAllUsers())
                .Returns(users);

            var user = new User
            {
                Name = "Ram"
            };

            // Act & Assert

            var exception = Assert.Throws<Exception>(() =>
                _userServices.CreateUser(user));

            Assert.Equal(
                "User already exists",
                exception.Message);
        }

        [Fact]
        public void DeleteUser_ShouldThrowException_WhenUserNotFound()
        {
            // Arrange

            _mockRepository
                .Setup(x => x.GetUserById(It.IsAny<int>()))
                .Returns((User?)null);

            // Act & Assert

            var exception = Assert.Throws<Exception>(() =>
                _userServices.DeleteActiveUser(1));

            Assert.Equal(
                "User not found",
                exception.Message);
        }
    }
}
