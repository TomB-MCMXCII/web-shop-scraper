using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WebShopScraper.Core;

namespace WebShopScraper.Test
{
    [TestClass]
    public class RepositoryTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void ProductsShouldBeAdded(IEnumerable<ElectricScooter> products)
        {
            //var repoMock = new Mock<IProductService>();
            
            //repoMock.Setup(_ => _.SaveProducts(products));
            
        }
        public static IEnumerable<ElectricScooter> GetData()
        {
            yield return new ElectricScooter() { Name = "Scooter Miyazaki" };
            yield return new ElectricScooter() { Name = "Scooter 2008" };
            yield return new ElectricScooter() { Name = "Scooter Arturio" };
        }

    }
}
