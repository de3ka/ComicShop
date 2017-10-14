using ComicShop.Data.Services.Contracts;
using ComicShop.Web.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ComicShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComicService comicService;

        public HomeController(IComicService comicService)
        {
            Guard.WhenArgument(comicService, "comicService").IsNull().Throw();

            this.comicService = comicService;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            List<ComicViewModel> comicsList =
               this.comicService.GetAllComics().ToList().Select(c => new ComicViewModel(c)).ToList();


            return View(comicsList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}