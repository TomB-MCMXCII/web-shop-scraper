using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace WebShopScraper.Test
{
    [TestClass]
    public class RepositoryTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void ProductsShouldBeAdded(IEnumerable<Product> products)
        {
            var repoMock = new Mock<IRepository>();
            
            

           
        }
        public static IEnumerable<Product> GetData()
        {
            yield return new Product() { Name = "Scooter Miyazaki" };
            yield return new Product() { Name = "Scooter 2008" };
            yield return new Product() { Name = "Scooter Arturio" };
        }

    }
}
