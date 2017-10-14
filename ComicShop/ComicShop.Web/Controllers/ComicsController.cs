using ComicShop.Data.Services.Contracts;
using ComicShop.Web.Models;
using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace ComicShop.Web.Controllers
{
    public class ComicsController : Controller
    {
        private readonly IComicService comicService;

        public ComicsController(IComicService comicService)
        {
            Guard.WhenArgument(comicService, "comicService").IsNull().Throw();

            this.comicService = comicService;
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var allComics = this.comicService.GetAllComics().ToList().Select(c => new ComicViewModel(c)).ToList();
            return View(allComics.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var targetComic = this.comicService.GetComicById((int)id);

                return View(targetComic);
            }
            else
            {
                return View(this.comicService.GetAllComics().First());
            }
        }
    }
}