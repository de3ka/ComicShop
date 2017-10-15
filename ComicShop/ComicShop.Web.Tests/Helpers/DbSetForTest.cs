using System.Data.Entity;

namespace ComicShop.Web.Tests.Helpers
{
    public class DbSetForTest<T> : DbSet<T> where T : class
    {
    }
}