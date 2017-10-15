using ComicShop.Data.Contracts;
using ComicShop.Data.Models.Contracts;
using ComicShop.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace ComicShop.Web.Tests.Data.EfComicShopDataProvider
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void ReturnCorrectResultWhenParameterIsValid()
        {
            // Arrange 
            var mockedDbSet = new Mock<DbSet<IComic>>();
            var mockedDbContext = new Mock<IComicShopDbContext>();
            var fakeAdvert = new Mock<IComic>();
            var validId = 15;

            // Act
            mockedDbContext.Setup(mock => mock.Set<IComic>()).Returns(mockedDbSet.Object);
            var dataProvider = new EfComicShopDataProvider<IComic>(mockedDbContext.Object);
            mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(fakeAdvert.Object);

            // Assert
            Assert.That(dataProvider.GetById(validId), Is.Not.Null);
            Assert.AreEqual(dataProvider.GetById(validId), fakeAdvert.Object);
        }
    }
}
