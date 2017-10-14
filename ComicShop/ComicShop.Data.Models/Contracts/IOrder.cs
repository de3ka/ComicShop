using System;
using System.Collections.Generic;

namespace ComicShop.Data.Models.Contracts
{
    public interface IOrder
    {
        int Id { get; set; }

        DateTime OrderedOn { get; set; }

        decimal TotalPrice { get; set; }

        int ItemsCount { get; set; }

        bool isProceeded { get; set; }

        string UserId { get; set; }

        User User { get; set; }

        IList<Comic> Comics { get; set; }
    }
}