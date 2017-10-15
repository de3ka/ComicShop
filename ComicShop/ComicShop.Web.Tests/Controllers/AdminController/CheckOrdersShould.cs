using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.AdminController
{
    [TestFixture]
    public class CheckOrdersShould
    {
        [Test]
        public void ReturnView()
        {
            //Arrange
            var comicServiceMock = new Mock<IComicService>();
            var orderServiceMock = new Mock<IOrderService>();
            Order order = new Order();
            var ordersList = new List<Order>() { order };
            orderServiceMock.Setup(x => x.GetAllOrders()).Returns(ordersList.AsQueryable);

            //Act
            var adminController = new ComicShop.Web.Areas.Admin.Controllers.AdminController(
                  comicServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.CheckOrders())
                .ShouldRenderDefaultView();
        }
    }
}
