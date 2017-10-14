using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicShop.Data
{
    public class ComicShopDbContext : IdentityDbContext<User>, IComicShopDbContext
    {
        public ComicShopDbContext()
            : base("DefaultConnection")
        {

        }

        public IDbSet<Comic> Comics { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public static ComicShopDbContext Create()
        {
            return new ComicShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
