using ComicShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ComicShop.Data.Services.Contracts
{
    public interface IOrderService
    {
        bool CreateOrder(string userId, IList<Comic> comicsList);

        IQueryable<Order> GetAllOrders();

        IQueryable<Order> GetOrdersByUserId(string userId);

        void ProceedOrderById(int id);
    }
}