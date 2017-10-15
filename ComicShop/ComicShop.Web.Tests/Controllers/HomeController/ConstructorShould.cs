using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace ComicShop.Web.Tests.Controllers.HomeController
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ReturnsAnInstanceWhenParameterIsNotNull()
        {
            // Arrange
            var comicServiceMock = new Mock<IComicService>();

            // Act
            var homeController = new ComicShop.Web.Controllers.HomeController(comicServiceMock.Object);

            // Assert
            Assert.IsNotNull(homeController);
        }

        [Test]
        public void ThrowExceptionWhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ComicShop.Web.Controllers.HomeController(null));
        }
    }
}
