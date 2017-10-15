using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using ComicShop.Web.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.OrderController
{
    [TestFixture]
    public class MyOrdersShould
    {
        [Test]
        public void ReturnViewWithCurrentUserOrdersList()
        {
            // Arrange
            var orderServiceMock = new Mock<IOrderService>();
            var currentUser = new User() { Id = "id" };
            var firstOrder = new Order() { UserId = "id" };
            var secondOrder = new Order() { UserId = "notMachedId" };
            var listOfOrders = new List<Order>()
            {
                firstOrder,
                secondOrder
            };

            orderServiceMock.Setup(x => x.GetOrdersByUserId("id")).Returns(listOfOrders.AsQueryable);

            // Act
            var orderController = new ComicShop.Web.Controllers.OrderController(orderServiceMock.Object);

            //Assert
            orderController
                .WithCallTo(c => c.MyOrders("id"))
                .ShouldRenderDefaultView()
                .WithModel<List<OrderViewModel>>(model =>
                {
                    Assert.AreEqual(model.First().UserId, currentUser.Id);
                });
        }
    }
}
