using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace ComicShop.Web.Tests.Controllers.ErrorController
{
    [TestFixture]
    public class ServerErrorShould
    {
        [Test]
        public void ReturnView()
        {
            //Arrange & Act
            var errorController = new ComicShop.Web.Controllers.ErrorController();

            //Assert
            errorController
                .WithCallTo(c => c.ServerError())
                .ShouldRenderDefaultView();
        }
    }
}
