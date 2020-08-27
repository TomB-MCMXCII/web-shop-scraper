using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Core
{
    public class ScooterService : IScooterService
    {
        private readonly IRepository<ElectricScooter> _repository;

        public ScooterService(IRepository<ElectricScooter> repository)
        {
            _repository = repository;
        }
        public void SaveProducts(IEnumerable<ElectricScooter> products)
        {
            _repository.SaveProducts(products);
            
        }

    }
}
