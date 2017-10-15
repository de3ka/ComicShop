using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace ComicShop.Web.Tests.Services.ComicService
{
    [TestFixture]
    public class GetAllComicsShould
    {
        [Test]
        public void CallComicDataProviderAllMethod()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();

            //Act
            var actualComicService =
                new ComicShop.Data.Services.ComicService(mockedDataProvider.Object);

            actualComicService.GetAllComics();

            //Assert
            mockedDataProvider.Verify(
                service => service.All(),
                Times.Once);
        }

        [Test]
        public void ReturnIqueryableCollectionFromCOMICDataProviderAllMethod()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();

            //Act
            var actualComicService =
                new ComicShop.Data.Services.ComicService(mockedDataProvider.Object);

            var actualResult = actualComicService.GetAllComics();

            //Assert
            Assert.That(actualResult, Is.Not.Null.And.InstanceOf<IQueryable<Comic>>());
        }
    }
}
