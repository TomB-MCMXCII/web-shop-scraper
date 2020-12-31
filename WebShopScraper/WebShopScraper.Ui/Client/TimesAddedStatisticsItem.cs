using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopScraper.Ui.Client
{
    public class TimesAddedStatisticsItem
    {
        public int ShopId { get; set; }
        public int CategoryId { get; set; }
        public string ShopName { get; set; }
        public int TimesAddedSum { get; set; }
    }
}
