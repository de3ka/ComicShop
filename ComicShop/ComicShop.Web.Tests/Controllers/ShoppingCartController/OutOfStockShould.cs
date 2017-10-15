using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.ShoppingCartController
{
    [TestFixture]
    public class OutOfStockShould
    {
        [Test]
        public void ReturnView()
        {

            // Arrange
            var comicServiceMock = new Mock<IComicService>();

            // Act
            var shoppingCartController = new ComicShop.Web.Controllers.ShoppingCartController(comicServiceMock.Object);

            //Assert
            shoppingCartController
                .WithCallTo(c => c.OutOfStock())
                .ShouldRenderDefaultView();
        }
    }
}
