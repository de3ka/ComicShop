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

namespace ComicShop.Web.Tests.Controllers.OrderController
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void RedirectToIndexActionWhenOrderServiceReturnTrue()
        {
            //// Arrange
            //var orderServiceMock = new Mock<IOrderService>();
            //var currentUser = new User() { Id = "id" };
            //var firstComic = new Comic();
            //var secondComic = new Comic();
            //var listOfComics = new List<Comic>()
            //{
            //    firstComic,
            //    secondComic
            //};

            //orderServiceMock.Setup(x => x.CreateOrder("id", listOfComics)).Returns(true);

            //// Act
            //var orderController = new ComicShop.Web.Controllers.OrderController(orderServiceMock.Object);
            ////orderController.HttpContext.Session;

            ////Assert
            //orderController
            //    .WithCallTo(c => c.Create("id"))
            //    .ShouldRedirectTo(a => a.Index);
        }
    }
}
