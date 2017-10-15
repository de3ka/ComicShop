using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace ComicShop.Web.Tests.Controllers.ShoppingCartController
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
            var shoppingCartController = new ComicShop.Web.Controllers.ShoppingCartController(comicServiceMock.Object);

            // Assert
            Assert.IsNotNull(shoppingCartController);
        }

        [Test]
        public void ThrowExceptionWhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ComicShop.Web.Controllers.ShoppingCartController(null));
        }
    }
}
