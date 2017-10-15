using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using Moq;
using NUnit.Framework;
using System;

namespace ComicShop.Web.Tests.Services.ComicService
{
    [TestFixture]
    public class UpdateComicShould
    {
        [Test]
        public void CallComicDataProviderUpdateMethodWithSameRecievedComic()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedComic = new Comic() { Id = 1 };

            mockedDataProvider.Setup(x => x.GetById(1)).Returns(mockedComic);

            //Act
            var actualComicService =
                new ComicShop.Data.Services.ComicService(mockedDataProvider.Object);

            actualComicService.UpdateComic(mockedComic);

            //Assert
            mockedDataProvider.Verify(
                service => service.Update(mockedComic),
                Times.Once);
        }

        [Test]
        public void CallComicDataProviderSaveChangesMethod()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();
            var mockedComic = new Comic() { Id = 1 };

            mockedDataProvider.Setup(x => x.GetById(1)).Returns(mockedComic);
            //Act
            var actualComicService =
                new ComicShop.Data.Services.ComicService(mockedDataProvider.Object);

            actualComicService.UpdateComic(mockedComic);

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
                () => actualComicService.UpdateComic(nullComic),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}