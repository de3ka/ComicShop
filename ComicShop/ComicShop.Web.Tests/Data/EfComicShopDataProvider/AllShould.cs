using ComicShop.Data.Contracts;
using ComicShop.Data.Models.Contracts;
using ComicShop.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace ComicShop.Web.Tests.Data.EfComicShopDataProvider
{
    [TestFixture]
    public class AllShould
    {
        [Test]
        public void AllShouldReturnEntitiesOfGivenSet()
        {
            // Arrange
            var mockedDbContext = new Mock<IComicShopDbContext>();
            var mockedSet = new Mock<DbSet<IComic>>();

            // Act
            mockedDbContext.Setup(x => x.Set<IComic>()).Returns(mockedSet.Object);
            var dataProvider = new EfComicShopDataProvider<IComic>(mockedDbContext.Object);

            // Assert
            Assert.NotNull(dataProvider.All());
            Assert.IsInstanceOf(typeof(DbSet<IComic>), dataProvider.All());
        }
    }
}
