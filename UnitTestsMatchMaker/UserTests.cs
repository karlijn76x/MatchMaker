using MatchMaker.Controllers;
using MatchMaker.Models;
using MatchMaker.Models.Entities;
using MatchMaker.Interfaces;
using MatchMaker.Data;
using MatchMaker.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace UnitTestsMatchMaker
{
    public class UserTests
    {
        private readonly UserController _controller;
        private readonly Mock<IApplicationDbContext> _dbContextMock;
        private readonly Mock<PasswordHelper> _passwordHelperMock;

        public UserTests()
        {
            _dbContextMock = new Mock<IApplicationDbContext>();
            _passwordHelperMock = new Mock<PasswordHelper>();
            _controller = new UserController(_dbContextMock.Object, _passwordHelperMock.Object);
        }

        [Fact]
        public void GetUsers_ShouldReturnOkWithUserList()
        {
            // Arrange
            var users = new List<User>
            {
              new User { Id = Guid.NewGuid(), Username = "user1", Email = "user1@example.com", PasswordHash = "hash1", Region = "Region1", Rank = "Silver" },
              new User { Id = Guid.NewGuid(), Username = "user2", Email = "user2@example.com", PasswordHash = "hash2", Region = "Region2", Rank = "Gold"}
            };

            _dbContextMock.Setup(db => db.Users).ReturnsDbSet(users);

            // Act
            var result = _controller.GetUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);


            var returnUsers = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value).ToList();
            Assert.Equal(users.Count, returnUsers.Count);


            Assert.Collection(returnUsers,
                user =>
                {
                    Assert.Equal(users[0].Username, user.Username);
                    Assert.Equal(users[0].Email, user.Email);
                },
                user =>
                {
                    Assert.Equal(users[1].Username, user.Username);
                    Assert.Equal(users[1].Email, user.Email);
                });
        }
    }
}