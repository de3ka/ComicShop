using ComicShop.Data.Models;
using System.Linq;

namespace ComicShop.Data.Services.Contracts
{
    public interface IComicService
    {
        void Create(Comic comic);

        IQueryable<Comic> GetAllComics();

        Comic GetComicById(int id);

        void UpdateComic(Comic comic);
    }
}
