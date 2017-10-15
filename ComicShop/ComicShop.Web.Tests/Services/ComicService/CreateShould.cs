using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using Moq;
using NUnit.Framework;
using System;

namespace ComicShop.Web.Tests.Services.ComicService
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void CallCreatureDataProviderAddMethodWithSameRecievedComic()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedComic = new Mock<Comic>();

            //Act
            var actualComicService =
                new ComicShop.Data.Services.ComicService(mockedDataProvider.Object);

            actualComicService.Create(mockedComic.Object);

            //Assert
            mockedDataProvider.Verify(
                service => service.Add(mockedComic.Object),
                Times.Once);
        }

        [Test]
        public void CallComicDataProviderSaveChangesMethod()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedComic = new Mock<Comic>();

            //Act
            var actualComicService =
                new ComicShop.Data.Services.ComicService(mockedDataProvider.Object);

            actualComicService.Create(mockedComic.Object);

            //Assert
            mockedDataProvider.Verify(
                service => service.SaveChanges(),
                Times.Once);
        }

        [Test]
        public void ThrowWhenArgumentComicHasNullValue()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            Comic nullComic = null;

            //Act
            var actualComicService =
                new ComicShop.Data.Services.ComicService(mockedDataProvider.Object);

            //Assert
            Assert.That(
                () => actualComicService.Create(nullComic),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
