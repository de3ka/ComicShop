using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace ComicShop.Web.Tests.Controllers.ComicsController
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
            var comicsController = new ComicShop.Web.Controllers.ComicsController(comicServiceMock.Object);

            // Assert
            Assert.IsNotNull(comicsController);
        }

        [Test]
        public void ThrowExceptionWhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ComicShop.Web.Controllers.ComicsController(null));
        }
    }
}
