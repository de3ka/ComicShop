using ComicShop.Data.Models;
using ComicShop.Data.Models.Contracts;
using NUnit.Framework;

namespace ComicShop.Web.Tests.Models
{
    [TestFixture]
    public class ComicModelSould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange & Act
            var actualComic = new Comic()
            {
                Id = 1,
                Name = "name",
                Description = "desc",
                AvailableCount = 2,
                Category = "marvel",
                ImageUrl = "http://site.com",
                Price = 12.5m,
                OrderedItemsCount = 3
            };

            //Assert
            Assert.That(
                () => new Comic(),
                Is.InstanceOf<IComic>());

            Assert.AreEqual(actualComic.Id, 1);
            Assert.AreEqual(actualComic.AvailableCount, 2);
            Assert.AreEqual(actualComic.Price, 12.5m);
            Assert.AreEqual(actualComic.Name, "name");
            Assert.AreEqual(actualComic.Description, "desc");
            Assert.AreEqual(actualComic.Category, "marvel");
            Assert.AreEqual(actualComic.ImageUrl, "http://site.com");
            Assert.AreEqual(actualComic.OrderedItemsCount, 3);
        }
    }
}