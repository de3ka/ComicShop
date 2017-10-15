using ComicShop.Data.Models;
using ComicShop.Web.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ComicShop.Web.Tests.ViewModels
{
    [TestFixture]
    public class OrderViewModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            var listOfComics = new List<Comic>() { new Comic() };
            var user = new User();

            var date = "Saturday, October 14, 2017 02:25";
            var format = "dddd, MMMM dd, yyyy hh:mm";

            var order = new Order()
            {
                Id = 1,
                OrderedOn = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture),
                TotalPrice = 123.5m,
                ItemsCount = 2,
                UserId = "4",
                User = user,
                Comics = listOfComics,
                isProceeded = false
            };

            //Act
            var orderViewModel = new OrderViewModel(order);

            //Assert
            Assert.AreEqual(order.Id, orderViewModel.Id);
            Assert.AreEqual(order.OrderedOn, orderViewModel.OrderedOn);
            Assert.AreEqual(order.TotalPrice, orderViewModel.TotalPrice);
            Assert.AreEqual(order.ItemsCount, orderViewModel.ItemsCount);
            Assert.AreEqual(order.UserId, orderViewModel.UserId);
            Assert.AreEqual(order.Comics, orderViewModel.Comics);
            Assert.AreEqual(order.User, orderViewModel.User);
            Assert.AreEqual(order.isProceeded, orderViewModel.isProceeded);
        }
    }
}
