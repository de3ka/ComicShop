using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicShop.Web.Tests.Services.OrderService
{
    [TestFixture]
    public class CreateOrderShould
    {
        [Test]
        public void CallOrderDataProviderAddAndSaveChangesMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedOrderToCreate = new Order();
            var mockedComic = new Comic() { Id = 2, Price = 5m, AvailableCount = 1 };

            mockedComicDataProvider.Setup(x => x.GetById(2)).Returns(mockedComic);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToCreate);

            actualOrderService.CreateOrder("Ak47", new List<Comic>() { mockedComic });

            //Assert
            mockedOrderDataProvider.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
            mockedOrderDataProvider.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void ReturnFalseWhenAvailableCountIsLessThanZero()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedOrderToCreate = new Order();
            var mockedComic = new Comic() { Id = 2, Price = 5m, AvailableCount = -1 };

            mockedComicDataProvider.Setup(x => x.GetById(2)).Returns(mockedComic);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToCreate);

            var result =
                actualOrderService.CreateOrder("Ak47", new List<Comic>() { mockedComic });

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}