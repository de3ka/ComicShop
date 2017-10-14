using ComicShop.Data.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ComicShop.Data.Contracts
{
    public interface IComicShopDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Comic> Comics { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}