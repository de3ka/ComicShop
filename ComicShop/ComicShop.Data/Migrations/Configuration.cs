using System.Data.Entity.Migrations;

namespace ComicShop.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ComicShop.Data.ComicShopDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

    }
}
