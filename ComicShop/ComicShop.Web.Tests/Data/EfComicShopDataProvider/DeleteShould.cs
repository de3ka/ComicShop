using ComicShop.Data.Contracts;
using ComicShop.Data.Models.Contracts;
using ComicShop.Data.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicShop.Web.Tests.Data.EfComicShopDataProvider
{
    [TestFixture]
    public class DeleteShould
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
            Assert.That(() => dataProvider.Delete(entity),
                Throws.InstanceOf<NullReferenceException>());
        }
    }
}
