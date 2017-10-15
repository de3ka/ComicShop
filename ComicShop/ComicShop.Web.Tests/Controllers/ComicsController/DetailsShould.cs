using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.ComicsController
{
    [TestFixture]
    public class DetailsShould
    {
        [Test]
        public void ReturnViewWithCorrectModelWhenParameterIdIsNotNull()
        {
            // Arrange
            var comicServiceMock = new Mock<IComicService>();
            Comic firstComic = new Comic() { Name = "Flash", Id = 1 };
            Comic secondComic = new Comic() { Name = "Batman", Id = 2 };
            var listOfComics = new List<Comic>() { firstComic, secondComic };

            comicServiceMock.Setup(x => x.GetComicById(1)).Returns(firstComic);

            // Act
            var comicController = new ComicShop.Web.Controllers.ComicsController(comicServiceMock.Object);

            //Assert
            comicController
                .WithCallTo(c => c.Details(1))
                .ShouldRenderDefaultView()
                .WithModel<Comic>(model =>
                {
                    Assert.IsInstanceOf(typeof(Comic), model);
                    Assert.AreEqual(model.Name, firstComic.Name);
                });
        }

        [Test]
        public void ReturnViewWithFirstModelInProvidedCollectionWhenParameterIdIsNull()
        {
            // Arrange
            var comicServiceMock = new Mock<IComicService>();
            Comic firstComic = new Comic() { Name = "Flash", Id = 1 };
            Comic secondComic = new Comic() { Name = "Batman", Id = 2 };
            var listOfComics = new List<Comic>() { firstComic, secondComic };

            comicServiceMock.Setup(x => x.GetAllComics()).Returns(listOfComics.AsQueryable);

            // Act
            var comicController = new ComicShop.Web.Controllers.ComicsController(comicServiceMock.Object);

            //Assert
            comicController
                .WithCallTo(c => c.Details(null))
                .ShouldRenderDefaultView()
                .WithModel<Comic>(model =>
                {
                    Assert.IsInstanceOf(typeof(Comic), model);
                    Assert.AreEqual(model, firstComic);
                });
        }
    }
}
