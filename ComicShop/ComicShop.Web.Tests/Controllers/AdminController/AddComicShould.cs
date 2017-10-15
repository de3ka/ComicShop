using System;
using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.AdminController
{
    [TestFixture]
    public class AddComicShould
    {
        [Test]
        public void ReturnView()
        {
            //Arrange
            var comicServiceMock = new Mock<IComicService>();
            var orderServiceMock = new Mock<IOrderService>();

            //Act
            var adminController = new ComicShop.Web.Areas.Admin.Controllers.AdminController(
                  comicServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.AddComic())
                .ShouldRenderDefaultView();
        }
    }
}