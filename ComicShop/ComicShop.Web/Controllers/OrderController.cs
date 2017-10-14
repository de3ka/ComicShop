using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using ComicShop.Web.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicShop.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            Guard.WhenArgument(orderService, "orderService").IsNull().Throw();

            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string userId)
        {
            var comicsList = new List<Comic>();

            if (Session["CartItems"] != null)
            {
                var cartItems = Session["CartItems"] as List<Comic>;
                for (int i = 0; i < cartItems.Count; i++)
                {
                    if (comicsList.Any(c => c.Id == cartItems[i].Id))
                    {
                        var targetComic = comicsList.First(c => c.Id == cartItems[i].Id);
                        targetComic.OrderedItemsCount += 1;
                    }
                    else
                    {
                        cartItems[i].OrderedItemsCount = 1;
                        comicsList.Add(cartItems[i]);
                    }
                }
                Session["CartItems"] = null;
            }

            bool isSuccess = this.orderService.CreateOrder(userId, comicsList);

            return isSuccess ? RedirectToAction("Index") : RedirectToAction("OutOfStock");
        }

        public ActionResult MyOrders(string id)
        {
            var cuurrentUsersOrders = this.orderService.GetOrdersByUserId(id).ToList().Select(o => new OrderViewModel(o)).ToList();
            return View(cuurrentUsersOrders);
        }
    }
}