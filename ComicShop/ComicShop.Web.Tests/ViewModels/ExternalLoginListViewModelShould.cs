using ComicShop.Web.Models;
using NUnit.Framework;

namespace ComicShop.Web.Tests.ViewModels
{
    [TestFixture]
    public class ExternalLoginListViewModelShould
    {
        [Test]
        public void SetCorrectlyAllPropertiesWhenInitialized()
        {
            //Arrange
            var externalLoginListViewModel = new ExternalLoginListViewModel();
            string url = "www.google.com";
            //Act
            externalLoginListViewModel.ReturnUrl = url;

            //Assert
            Assert.AreEqual(externalLoginListViewModel.ReturnUrl, url);
        }
    }
}