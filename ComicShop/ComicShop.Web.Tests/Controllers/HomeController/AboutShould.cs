using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.HomeController
{
    [TestFixture]
    public class AboutShould
    {
        [Test]
        public void ReturnViewWithListOfCorrectModelsWhenThereAreAnyExisting()
        {
            // Arrange
            var comicServiceMock = new Mock<IComicService>();

            // Act
            var homeController = new ComicShop.Web.Controllers.HomeController(comicServiceMock.Object);
            var viewResult = homeController.About() as ViewResult;

            //Assert
            homeController
                .WithCallTo(c => c.About())
                .ShouldRenderDefaultView();

            Assert.AreEqual("Your application description page.", viewResult.ViewData["Message"]);
        }
    }
}
