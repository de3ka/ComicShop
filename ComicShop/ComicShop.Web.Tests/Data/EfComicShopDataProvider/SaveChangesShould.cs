using ComicShop.Data.Contracts;
using ComicShop.Data.Models.Contracts;
using ComicShop.Data.Repositories;
using Moq;
using NUnit.Framework;
using System.Data.Entity;

namespace ComicShop.Web.Tests.Data.EfComicShopDataProvider
{
    [TestFixture]
    public class SaveChangesShould
    {
        [Test]
        public void BeCalledWhenDisposingProvider()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<IComic>>();
            var mockedDbContext = new Mock<IComicShopDbContext>();
            mockedDbContext.Setup(x => x.Set<IComic>()).Returns(mockedSet.Object);
            var dataProvider = new EfComicShopDataProvider<IComic>(mockedDbContext.Object);

            // Act
            dataProvider.SaveChanges();

            // Assert
            mockedDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
