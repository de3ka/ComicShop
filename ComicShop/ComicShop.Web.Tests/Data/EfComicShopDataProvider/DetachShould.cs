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
    public class DetachShould
    {
        [Test]
        public void BeCalledWhenInvoked()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<IComic>>();
            var mockedDbContext = new Mock<IComicShopDbContext>();
            mockedDbContext.Setup(x => x.Set<IComic>()).Returns(mockedSet.Object);
            var dataProvider = new EfComicShopDataProvider<IComic>(mockedDbContext.Object);
            var mockedAdvert = new Mock<IComic>();

            // Act
            try
            {
                dataProvider.Detach(mockedAdvert.Object);
            }
            catch (NullReferenceException) { };

            // Assert
            mockedDbContext.Verify(x => x.Entry(mockedAdvert.Object), Times.AtLeastOnce);
        }
    }
}
