using ComicShop.Data.Models;
using ComicShop.Web.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace ComicShop.Web.Tests.ViewModels
{
    [TestFixture]
    public class ComicViewModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            var comic = new Comic()
            {
                Id = 1,
                Name = "name",
                Description = "desc",
                AvailableCount = 2,
                Category = "marvel",
                ImageUrl = "http://site.com",
                Price = 12.5m,
                Orders = new List<Order>() { new Order() }
            };

            //Act
            var comicViewModel = new ComicViewModel(comic);

            //Assert
            Assert.AreEqual(comic.Id, comicViewModel.Id);
            Assert.AreEqual(comic.AvailableCount, comicViewModel.AvailableCount);
            Assert.AreEqual(comic.Price, comicViewModel.Price);
            Assert.AreEqual(comic.Name, comicViewModel.Name);
            Assert.AreEqual(comic.Description, comicViewModel.Description);
            Assert.AreEqual(comic.Category, comicViewModel.Category);
            Assert.AreEqual(comic.ImageUrl, comicViewModel.ImageUrl);
            Assert.AreEqual(comic.OrderedItemsCount, comicViewModel.OrderedItemsCount);
            Assert.AreEqual(comic.Orders, comicViewModel.Orders);
        }
    }
}