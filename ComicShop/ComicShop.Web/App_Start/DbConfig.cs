using ComicShop.Data;
using ComicShop.Data.Migrations;
using System.Data.Entity;

namespace ComicShop.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ComicShopDbContext, Configuration>());
            ComicShopDbContext.Create().Database.CreateIfNotExists();
        }
    }
}