using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace ComicShop.Web.Tests.Services.ComicService
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void InitializeNewInstanceOfIComicServiceWhenProperParameterIsPassed()
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();

            //Act & Assert
            Assert.That(
                () => new ComicShop.Data.Services.ComicService(mockedDataProvider.Object),
                Is.InstanceOf<IComicService>());
        }

        [Test]
        public void ThrowWhenNullParameterIsPassed()
        {
            //Arrange
            IEfComicShopDataProvider<Comic> nullDataProvider = null;

            //Act & Assert
            Assert.That(
                () => new ComicShop.Data.Services.ComicService(nullDataProvider),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
