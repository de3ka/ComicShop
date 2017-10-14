using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ComicShop.Web.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IComicService comicService;

        public ShoppingCartController(IComicService comicService)
        {
            Guard.WhenArgument(comicService, "comicService").IsNull().Throw();

            this.comicService = comicService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OutOfStock()
        {
            return View();
        }

        public ActionResult AddToCart(int? id)
        {
            int parsedId = (id == null) ? 0 : (int)id;

            var cartItem = this.comicService.GetComicById(parsedId);

            if (cartItem.AvailableCount >= 1)
            {

                if (Session["CartItems"] == null)
                {
                    List<Comic> cartItems = new List<Comic>();
                    cartItems.Add(cartItem);
                    Session["CartItems"] = cartItems;
                }
                else
                {
                    var cartItems = Session["CartItems"] as List<Comic>;
                    cartItems.Add(cartItem);
                    Session["CartItems"] = cartItems;
                }

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("OutOfStock");
            }
        }

        public ActionResult RemoveFromCart(int? id)
        {
            int parsedId = (id == null) ? 0 : (int)id;

            var cartItem = this.comicService.GetComicById(parsedId);

            if (Session["CartItems"] != null)
            {
                var cartItems = Session["CartItems"] as List<Comic>;
                var target = cartItems.FirstOrDefault(x => x.Id == cartItem.Id);
                cartItems.Remove(target);
                Session["CartItems"] = cartItems;
            }

            return RedirectToAction("Index");
        }
    }
}