using ComicShop.Data.Services;
using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace ComicShop.Web.Tests.Controllers.AdminController
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnsAnInstanceWhenParameterIsNotNull()
        {
            // Arrange
            var comicServiceMock = new Mock<IComicService>();
            var orderServiceMock = new Mock<IOrderService>();

            // Act
            var adminController = new ComicShop.Web.Areas.Admin.Controllers.AdminController(
                comicServiceMock.Object, orderServiceMock.Object);

            // Assert
            Assert.IsNotNull(adminController);
        }

        [Test]
        public void ThrowExceptionWhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ComicShop.Web.Areas.Admin.Controllers.AdminController(null, null));
        }

        [Test]
        public void ThrowExceptionWhenComicServiceIsNull()
        {
            // Arrange
            ComicService comicServiceMock = null;
            var orderServiceMock = new Mock<IOrderService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ComicShop.Web.Areas.Admin.Controllers.AdminController(comicServiceMock, orderServiceMock.Object));
        }

        [Test]
        public void ThrowExceptionWhenOrderServiceIsNull()
        {
            // Arrange
            var comicServiceMock = new Mock<IComicService>();
            OrderService orderServiceMock = null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ComicShop.Web.Areas.Admin.Controllers.AdminController(comicServiceMock.Object, orderServiceMock));
        }
    }
}