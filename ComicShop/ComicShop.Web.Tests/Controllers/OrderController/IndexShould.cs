using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.OrderController
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void ReturnView()
        {
            // Arrange
            var orderServiceMock = new Mock<IOrderService>();

            // Act
            var comicController = new ComicShop.Web.Controllers.OrderController(orderServiceMock.Object);

            //Assert
            comicController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
