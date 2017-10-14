namespace ComicShop.Data.Models.Contracts
{
    public interface IComic
    {
        string Name { get; set; }

        string ImageUrl { get; set; }

        string Category { get; set; }

        string Description { get; set; }

        int AvailableCount { get; set; }

        int OrderedItemsCount { get; set; }

        decimal Price { get; set; }
    }
}