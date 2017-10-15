using ComicShop.Data;
using System.Data.Entity;

namespace ComicShop.Web.Tests.Helpers
{
    public class DbContextForTest : ComicShopDbContext
    {
        public void TestModelCreation(DbModelBuilder model)
        {
            OnModelCreating(model);
        }
    }
}
