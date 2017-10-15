using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.AdminController
{
    [TestFixture]
    public class ProceedOrderByIdShould
    {
        [Test]
        public void CallOrderServiceProceedOrderByIdMethodWithPassedId()
        {
            //Arrange
            var comicServiceMock = new Mock<IComicService>();
            var orderServiceMock = new Mock<IOrderService>();

            //Act
            var adminController = new ComicShop.Web.Areas.Admin.Controllers.AdminController(
                  comicServiceMock.Object, orderServiceMock.Object);

            adminController.ProceedOrderById(1);

            //Assert
            orderServiceMock.Verify(x => x.ProceedOrderById(1), Times.Once);
        }

        [Test]
        public void RedirectToActionCheckOrders()
        {
            //Arrange
            var comicServiceMock = new Mock<IComicService>();
            var orderServiceMock = new Mock<IOrderService>();

            //Act
            var adminController = new ComicShop.Web.Areas.Admin.Controllers.AdminController(
                  comicServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.ProceedOrderById(1))
                .ShouldRedirectTo(x => x.CheckOrders);
        }
    }
}
