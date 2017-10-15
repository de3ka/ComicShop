using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using ComicShop.Web.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;
using PagedList;

namespace ComicShop.Web.Tests.Controllers.HomeController
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void ReturnViewWithListOfCorrectModelsWhenThereAreAnyExisting()
        {
            // Arrange
            var comicServiceMock = new Mock<IComicService>();
            Comic firstComic = new Comic() { Name = "Flash" };
            Comic secondComic = new Comic() { Name = "Batman" };

            var listOfComics = new List<Comic>() { firstComic, secondComic };

            // Act
            var homeController = new ComicShop.Web.Controllers.HomeController(comicServiceMock.Object);

            //Assert
            homeController
                .WithCallTo(c => c.Index(1))
                .ShouldRenderDefaultView()
                .WithModel<PagedList<ComicViewModel>>();
        }
    }
}
