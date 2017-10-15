using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace ComicShop.Web.Tests.Services.OrderService
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitializeNewInstanceOfIOrderServiceWhenProperParameterIsPassed()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedOrderToCreate = new Mock<Order>();

            //Act & Assert
            Assert.That(
                () => new ComicShop.Data.Services.OrderService(
                    mockedOrderDataProvider.Object,
                    mockedComicDataProvider.Object,
                    mockedOrderToCreate.Object),
                Is.InstanceOf<IOrderService>());
        }
    }
}
