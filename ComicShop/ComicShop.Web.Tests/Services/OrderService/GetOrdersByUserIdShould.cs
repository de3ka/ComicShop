using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ComicShop.Web.Tests.Services.OrderService
{
    [TestFixture]
    public class GetOrdersByUserIdShould
    {
        [Test]
        public void CallOrderDataProviderAllMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedOrderToCreate = new Order();
            var userId = "Ak47";

            mockedOrderDataProvider.Setup(x => x.All()).Returns(new List<Order>().AsQueryable);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToCreate);

            actualOrderService.GetOrdersByUserId(userId);

            //Assert
            mockedOrderDataProvider.Verify(x => x.All(), Times.Once);
        }

        [Test]
        public void ReturnOnlyOrderdsWithPassedUserId()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedOrderToCreate = new Order();
            var userId = "Ak47";
            var matchingOrder = new Order()
            {
                UserId = userId
            };

            var notMatchingOrder = new Order()
            {
                UserId = "notMatchedId"
            };

            var ordersList = new List<Order>() { matchingOrder, notMatchingOrder };

            // ordersList has 2 orders but only one matches userId
            int expectedCount = 1;

            mockedOrderDataProvider.Setup(x => x.All()).Returns(ordersList.AsQueryable);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToCreate);

            var resultOrdersList = actualOrderService.GetOrdersByUserId(userId);

            //Assert
            Assert.AreEqual(resultOrdersList.Count(), expectedCount);
            Assert.Contains(matchingOrder, resultOrdersList.ToList());
        }
    }
}
