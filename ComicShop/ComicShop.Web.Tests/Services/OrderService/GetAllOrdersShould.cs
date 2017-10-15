using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ComicShop.Web.Tests.Services.OrderService
{
    [TestFixture]
    public class GetAllOrdersShould
    {
        [Test]
        public void CallOrderDataProviderAllMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedOrderToCreate = new Order();

            mockedOrderDataProvider.Setup(x => x.All()).Returns(new List<Order>().AsQueryable);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToCreate);

            actualOrderService.GetAllOrders();

            //Assert
            mockedOrderDataProvider.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void ReturnIQueryableOrdersCollectionProvidedFromOrderDataProviderAllMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedOrderToCreate = new Order();
            var mockedOrdersCollection = new List<Order>() { mockedOrderToCreate };

            mockedOrderDataProvider.Setup(x => x.All()).Returns(mockedOrdersCollection.AsQueryable);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToCreate);

            var resultOrdersCollection = actualOrderService.GetAllOrders();

            //Assert
            Assert.AreEqual(mockedOrdersCollection, resultOrdersCollection);
            Assert.That(resultOrdersCollection, Is.InstanceOf<IQueryable<Order>>());
        }
    }
}
