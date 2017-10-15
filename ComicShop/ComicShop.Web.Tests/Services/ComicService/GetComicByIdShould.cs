using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using Moq;
using NUnit.Framework;

namespace ComicShop.Web.Tests.Services.ComicService
{
    [TestFixture]
    public class GetComicByIdShould
    {
        [TestCase(1)]
        [TestCase(5)]
        public void CallComicDataProviderGetAllMethodWithSameId(int correctId)
        {
            //Arrange
            var mockedDataProvider = new Mock<IEfComicShopDataProvider<Comic>>();

            //Act
            var actualComicService =
                new ComicShop.Data.Services.ComicService(mockedDataProvider.Object);

            actualComicService.GetComicById(correctId);

            //Assert
            mockedDataProvider.Verify(
                service => service.GetById(correctId),
                Times.Once);
        }
    }
}
