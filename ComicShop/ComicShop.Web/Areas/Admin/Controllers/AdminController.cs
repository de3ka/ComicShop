using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using Bytes2you.Validation;
using System.Web.Mvc;

namespace ComicShop.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly IComicService comicService;
        private readonly IOrderService orderService;

        public AdminController(IComicService comicService, IOrderService orderService)
        {
            Guard.WhenArgument(comicService, "comicService").IsNull().Throw();
            Guard.WhenArgument(orderService, "orderService").IsNull().Throw();

            this.comicService = comicService;
            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddComic()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComic([Bind(Include = "Id,Name,Address,Category,Description,AvailableCount,ImageUrl")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                this.comicService.Create(comic);
                return RedirectToAction("Index");
            }

            return View(comic);
        }

        public ActionResult EditComic(int? id)
        {
            Comic targetComic = this.comicService.GetComicById((int)id);

            return View(targetComic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComic([Bind(Include = "Id,Price,Name,Category,Description,AvailableCount,ImageUrl")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                this.comicService.UpdateComic(comic);
                return RedirectToAction("Index");
            }

            return View(comic);
        }

        public ActionResult CheckOrders()
        {
            return View(this.orderService.GetAllOrders());
        }

        public ActionResult ProceedOrderById(int orderId)
        {
            this.orderService.ProceedOrderById(orderId);
            return RedirectToAction("CheckOrders");
        }
    }
}