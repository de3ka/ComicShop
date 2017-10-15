using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using Moq;
using NUnit.Framework;

namespace ComicShop.Web.Tests.Services.OrderService
{
    [TestFixture]
    public class ProceedOrderByIdShould
    {
        [Test]
        public void CallOrderDataProviderGetByIdMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var orderId = 5;
            var mockedOrderToUpdate = new Order() { Id = orderId };


            mockedOrderDataProvider.Setup(x => x.GetById(orderId)).Returns(mockedOrderToUpdate);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToUpdate);

            actualOrderService.ProceedOrderById(orderId);

            //Assert
            mockedOrderDataProvider.Verify(x => x.GetById(orderId), Times.Once);
        }

        [Test]
        public void CallOrderDataProviderSaveChangesMethod()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var orderId = 5;
            var mockedOrderToUpdate = new Order() { Id = orderId };


            mockedOrderDataProvider.Setup(x => x.GetById(orderId)).Returns(mockedOrderToUpdate);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToUpdate);

            actualOrderService.ProceedOrderById(orderId);

            //Assert
            mockedOrderDataProvider.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void SetOrderToUpdateIsProceededValueToTrue()
        {
            //Arrange
            var mockedOrderDataProvider = new Mock<IEfComicShopDataProvider<Order>>();
            var mockedComicDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var orderId = 5;
            var mockedOrderToUpdate = new Order() { Id = orderId, isProceeded = false };


            mockedOrderDataProvider.Setup(x => x.GetById(orderId)).Returns(mockedOrderToUpdate);

            //Act
            var actualOrderService = new ComicShop.Data.Services.OrderService(
                mockedOrderDataProvider.Object,
                mockedComicDataProvider.Object,
                mockedOrderToUpdate);

            actualOrderService.ProceedOrderById(orderId);

            //Assert
            Assert.AreEqual(mockedOrderToUpdate.isProceeded, true);
        }
    }
}
