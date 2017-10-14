using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using ComicShop.Data.Models.Contracts;
using ComicShop.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComicShop.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEfComicShopDataProvider<Order> orderDataProvider;
        private readonly IEfComicShopDataProvider<Comic> comicDataProvider;
        private readonly IOrder orderToCreate;

        public OrderService(
            IEfComicShopDataProvider<Order> orderDataProvider,
            IEfComicShopDataProvider<Comic> comicDataProvider,
            IOrder orderToCreate)
        {
            this.orderDataProvider = orderDataProvider;
            this.comicDataProvider = comicDataProvider;
            this.orderToCreate = orderToCreate;
        }

        public bool CreateOrder(string userId, IList<Comic> comicsList)
        {

            this.orderToCreate.UserId = userId;
            this.orderToCreate.OrderedOn = DateTime.Now;
            this.orderToCreate.isProceeded = false;
            this.orderToCreate.Comics = new List<Comic>();

            decimal totalPrice = 0;
            foreach (var item in comicsList)
            {
                var currentComic = this.comicDataProvider.GetById(item.Id);
                currentComic.OrderedItemsCount = item.OrderedItemsCount;
                orderToCreate.ItemsCount += item.OrderedItemsCount;
                this.orderToCreate.Comics.Add(currentComic);
                if (currentComic.AvailableCount - item.OrderedItemsCount >= 0)
                {
                    currentComic.AvailableCount -= item.OrderedItemsCount;
                    this.comicDataProvider.SaveChanges();
                }
                else
                {
                    return false;
                }

                totalPrice += item.Price * item.OrderedItemsCount;
            }

            this.orderToCreate.TotalPrice = totalPrice;

            this.orderDataProvider.Add((Order)this.orderToCreate);
            this.orderDataProvider.SaveChanges();
            return true;
        }

        public IQueryable<Order> GetOrdersByUserId(string userId)
        {
            return this.orderDataProvider.All().Where(o => o.UserId == userId);
        }

        public IQueryable<Order> GetAllOrders()
        {
            return this.orderDataProvider.All();
        }

        public void ProceedOrderById(int id)
        {
            var targetOrder = this.orderDataProvider.GetById(id);
            targetOrder.isProceeded = true;
            this.orderDataProvider.SaveChanges();
        }
    }
}