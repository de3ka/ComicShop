using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using ComicShop.Web.Tests.Helpers;
using NUnit.Framework;

namespace ComicShop.Web.Tests.Data.ComicShopDbContext
{
    [TestFixture]
    public class ConstructorShould
    {
       /* [Test]
        public void HaveParameterlessConstructor()
        {
            // Arrange & Act
            var context = new ComicShop.Data.ComicShopDbContext();

            // Assert
            Assert.IsInstanceOf<ComicShop.Data.ComicShopDbContext>(context);
        }*/

       /* [Test]
        public void Return_InstanceOfIComicShopDbContext()
        {
            // Arrange & Act
            var context = new ComicShop.Data.ComicShopDbContext();

            // Assert
            Assert.IsInstanceOf<IComicShopDbContext>(context);
        }*/

        /* [Test]
         public void SetComicsDbSetAndOrdersDbSet()
         {
             // Arrange
             var context = new ComicShop.Data.ComicShopDbContext();
             var comics = new DbSetForTest<Comic>();
             var orders = new DbSetForTest<Order>();

             //Act
             context.Comics = comics;
             context.Orders = orders;

             //Assert
             Assert.AreEqual(context.Comics, comics);
             Assert.AreEqual(context.Orders, orders);
         }*/
    }
}