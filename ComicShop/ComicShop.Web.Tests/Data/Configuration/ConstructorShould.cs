using NUnit.Framework;

namespace ComicShop.Web.Tests.Data.Configuration
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void SetPropertiesAutomaticMigrationsEnabledAndAutomaticMigrationDataLossAllowedToTrue()
        {
            var config = new ComicShop.Data.Migrations.Configuration();

            Assert.AreEqual(config.AutomaticMigrationsEnabled, true);
            Assert.AreEqual(config.AutomaticMigrationDataLossAllowed, true);
        }
    }
}