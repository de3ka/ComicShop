using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.AdminController
{
    [TestFixture]
    public class EditComicPostShould
    {
        [Test]
        public void RedirectToIndexActionResultWhenModelStateIsValid()
        {
            //Arrange
            var comicServiceMock = new Mock<IComicService>();
            var orderServiceMock = new Mock<IOrderService>();
            Comic comic = new Comic();

            //Act
            var adminController = new ComicShop.Web.Areas.Admin.Controllers.AdminController(
                  comicServiceMock.Object, orderServiceMock.Object);

            //Assert
            adminController
                .WithCallTo(c => c.EditComic(comic))
                .ShouldRedirectTo(x => x.Index);
        }

        [Test]
        public void ReturnDefaultViewWhenModelStateIsNotValid()
        {
            //Arrange
            var comicServiceMock = new Mock<IComicService>();
            var orderServiceMock = new Mock<IOrderService>();
            Comic comic = new Comic();

            //Act
            var adminController = new ComicShop.Web.Areas.Admin.Controllers.AdminController(
                  comicServiceMock.Object, orderServiceMock.Object);

            adminController.ModelState.AddModelError("testError", "error detected");

            //Assert
            adminController
                .WithCallTo(c => c.EditComic(comic))
                .ShouldRenderDefaultView();
        }
    }
}