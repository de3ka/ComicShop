using ComicShop.Data.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicShop.Web.Models
{
    public class ComicViewModel
    {
        public ComicViewModel(Comic comic)
        {
            if (comic != null)
            {
                this.Id = comic.Id;
                this.Name = comic.Name;
                this.Description = comic.Description;
                this.Category = comic.Category;
                this.AvailableCount = comic.AvailableCount;
                this.ImageUrl = comic.ImageUrl;
                this.Price = comic.Price;
                this.OrderedItemsCount = comic.OrderedItemsCount;
                this.Orders = new List<Order>(comic.Orders);
            }
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("Preview")]
        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        [DisplayName("Available Count")]
        public int AvailableCount { get; set; }

        public int OrderedItemsCount { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}