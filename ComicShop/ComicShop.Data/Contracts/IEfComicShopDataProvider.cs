﻿using System;
using System.Linq;

namespace ComicShop.Data.Contracts
{
    public interface IEfComicShopDataProvider<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}