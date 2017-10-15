using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.HomeController
{
    [TestFixture]
    public class ContactShould
    {
        [Test]
        public void ReturnViewWithListOfCorrectModelsWhenThereAreAnyExisting()
        {
            // Arrange
            var comicServiceMock = new Mock<IComicService>();

            // Act
            var homeController = new ComicShop.Web.Controllers.HomeController(comicServiceMock.Object);
            var viewResult = homeController.Contact() as ViewResult;

            //Assert
            homeController
                .WithCallTo(c => c.Contact())
                .ShouldRenderDefaultView();

            Assert.AreEqual("Your contact page.", viewResult.ViewData["Message"]);
        }
    }
}
