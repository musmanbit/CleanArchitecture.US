using System;
using System.Threading.Tasks;
using CleanArchitecture.US.API.Authentication.Controllers;
using CleanArchitecture.US.Application.Interface;
using CleanArchitecture.US.Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.US.Tests.Admin
{
    public class AdminUnitTest
    {
        [SetUp]
        public void Setup()
        {
            // setup necessary required items
        }



        [Test]

        [TestCase(6)]
        public async Task Admin_GetById_returns_admin(int id)
        {

            var mockUser = new Mock<IUserApplication>();
            
            var mockAdmin = new Mock<IAdminApplication>();
            var adminController = new AdminController(null, null, mockAdmin.Object, mockUser.Object);

            mockAdmin.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((GetAdminMock()));

            //Act
            var result = await adminController.Get(id);
            

            //Assert
            Assert.NotNull(result);
        }

        private Domain.Admin GetAdminMock()
        {
            return new Domain.Admin()
            {
                AdminId = 5,
                CreatedBy = 6,
                FirstName = "Mock First Name"
            };
        }
    }
}