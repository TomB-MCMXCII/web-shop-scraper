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
            var repoServiceMock = new Mock<IDataAccess>();
            

            repoMock.Setup(_ => _.SaveProducts(products));
            repoServiceMock.Setup(_ => _.GetByName());
        }
        public static IEnumerable<Product> GetData()
        {
            yield return new Product() { Name = "Scooter Miyazaki" };
            yield return new Product() { Name = "Scooter 2008" };
            yield return new Product() { Name = "Scooter Arturio" };
        }

    }
}
