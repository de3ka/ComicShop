using ComicShop.Data.Contracts;
using ComicShop.Data.Models.Contracts;
using ComicShop.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace ComicShop.Web.Tests.Data.EfComicShopDataProvider
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionIfDbContextPassedIsNull()
        {
            // Arrange
            IComicShopDbContext nullContext = null;

            // Act & Assert
            Assert.That(() => new EfComicShopDataProvider<IComic>(nullContext),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void WorkCorrectlyIfDbContextPassedIsValid()
        {
            // Arrange
            var mockedDbContext = new Mock<IComicShopDbContext>();
            var mockedModel = new Mock<DbSet<IComic>>();

            // Act
            mockedDbContext.Setup(x => x.Set<IComic>()).Returns(mockedModel.Object);
            var dataProvider = new EfComicShopDataProvider<IComic>(mockedDbContext.Object);

            // Assert
            Assert.That(dataProvider, Is.Not.Null);
        }

        [Test]
        public void SetContextCorrectlyWhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IComicShopDbContext>();
            var mockedModel = new Mock<DbSet<IComic>>();

            // Act
            mockedContext.Setup(x => x.Set<IComic>()).Returns(mockedModel.Object);
            var dataProvider = new EfComicShopDataProvider<IComic>(mockedContext.Object);

            // Assert
            Assert.That(dataProvider.Context, Is.Not.Null);
            Assert.That(dataProvider.Context, Is.EqualTo(mockedContext.Object));
        }

        [Test]
        public void SetDbSetCorrectlyWhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<IComicShopDbContext>();
            var mockedModel = new Mock<DbSet<IComic>>();

            // Act
            mockedContext.Setup(x => x.Set<IComic>()).Returns(mockedModel.Object);
            var repository = new EfComicShopDataProvider<IComic>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }
    }
}
