using Bytes2you.Validation;
using ComicShop.Data.Contracts;
using ComicShop.Data.Models;
using ComicShop.Data.Services.Contracts;
using System.Linq;

namespace ComicShop.Data.Services
{
    public class ComicService : IComicService
    {
        private readonly IEfComicShopDataProvider<Comic> comicDataProvider;

        public ComicService(IEfComicShopDataProvider<Comic> comicDataProvider)
        {
            Guard.WhenArgument(comicDataProvider, "comicDataProvider").IsNull().Throw();

            this.comicDataProvider = comicDataProvider;
        }

        public void Create(Comic comic)
        {
            Guard.WhenArgument(comic, "comic").IsNull().Throw();

            this.comicDataProvider.Add(comic);
            this.comicDataProvider.SaveChanges();
        }

        public IQueryable<Comic> GetAllComics()
        {
            return this.comicDataProvider.All();
        }

        public Comic GetComicById(int id)
        {
            return this.comicDataProvider.GetById(id);
        }

        public void UpdateComic(Comic comic)
        {
            Guard.WhenArgument(comic, "comic").IsNull().Throw();

            var targetComic = this.comicDataProvider.GetById(comic.Id);
            targetComic.Name = comic.Name;
            targetComic.Description = comic.Description;
            targetComic.AvailableCount = comic.AvailableCount;
            targetComic.Price = comic.Price;
            targetComic.ImageUrl = comic.ImageUrl;
            targetComic.Category = comic.Category;

            this.comicDataProvider.Update(targetComic);
            this.comicDataProvider.SaveChanges();
        }
    }
}