using ComicShop.Data.Models;
using ComicShop.Data.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ComicShop.Web.Tests.Models
{
    [TestFixture]
    public class OrderModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange & Act
            var listOfComics = new List<Comic>() { new Comic() };
            var user = new User();

            var date = "Saturday, October 14, 2017 02:25";
            var format = "dddd, MMMM dd, yyyy hh:mm";

            var actualOrder = new Order()
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

            //Assert
            Assert.That(
                () => new Order(), Is.InstanceOf<IOrder>());

            Assert.AreEqual(actualOrder.Id, 1);
            Assert.AreEqual(actualOrder.OrderedOn, DateTime.ParseExact(date, format, CultureInfo.InvariantCulture));
            Assert.AreEqual(actualOrder.TotalPrice, 123.5m);
            Assert.AreEqual(actualOrder.ItemsCount, 2);
            Assert.AreEqual(actualOrder.UserId, "4");
            Assert.AreEqual(actualOrder.Comics, listOfComics);
            Assert.AreEqual(actualOrder.User, user);
            Assert.AreEqual(actualOrder.isProceeded, false);
        }
    }
}
