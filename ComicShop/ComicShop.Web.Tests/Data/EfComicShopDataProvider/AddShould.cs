using ComicShop.Data.Contracts;
using ComicShop.Data.Models.Contracts;
using ComicShop.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Serialization;

namespace ComicShop.Web.Tests.Data.EfComicShopDataProvider
{
    [TestFixture]
    public class AddShould
    {
        [Test]
        public void ThrowNullReferenceExceptionWhenPassedArgumentIsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<IComicShopDbContext>();
            var mockedSet = new Mock<DbSet<IComic>>();

            // Act
            mockedDbContext.Setup(set => set.Set<IComic>()).Returns(mockedSet.Object);
            var dataProvider = new EfComicShopDataProvider<IComic>(mockedDbContext.Object);
            IComic entity = null;

            // Assert
            Assert.That(() => dataProvider.Add(entity),
                Throws.InstanceOf<NullReferenceException>());
        }
    }
}
