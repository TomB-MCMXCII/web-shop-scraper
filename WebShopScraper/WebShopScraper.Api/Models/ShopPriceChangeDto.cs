using System.Collections.Generic;

namespace WebShopScraper.Api.Models
{
    public class ShopPriceChangeListDto
    {
        public List<ShopPriceChangeListItem> ShopPriceChangeListItem { get; set; }
        public int CategoryId { get; set; }
    }
}