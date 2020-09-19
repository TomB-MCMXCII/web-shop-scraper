using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Test
{
    [TestClass]
    public class ProductServiceShould
    {
        private static Mock<IRepository<Product>> _repoMock;
        private static ProductService<Product> _productService;

        [TestInitialize]
        public void Product()
        {
            _repoMock = new Mock<IRepository<Product>>();
            _productService = new ProductService<Product>(_repoMock.Object);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetProducts), DynamicDataSourceType.Method)]
        public void save_products(IEnumerable<Product> products)
        {
            //Act
            _productService.SaveProducts(products);
            //Assert
            _repoMock.Verify(x => x.Create(It.IsAny<IEnumerable<Product>>()),Times.Once);

        }

        [DataTestMethod]
        [DynamicData(nameof(GetProducts), DynamicDataSourceType.Method)]
        public void update_products(IEnumerable<Product> products)
        {
            //Act
            _productService.SaveProducts(products);
            //Assert
            _repoMock.Verify(x => x.Update(It.IsAny<IEnumerable<Product>>()), Times.Once);

        }

        [DataTestMethod]
        [DynamicData(nameof(GetProducts), DynamicDataSourceType.Method)]
        public void save_products_which_do_not_exist(IEnumerable<Product> products)
        {
            //Arrange
            var productCount = products.Count();
            _repoMock.SetupSequence(x => x.ReadByName(It.IsAny<string>()))
                .Returns(products.ElementAt(0))
                .Returns((Product)null)
                .Returns((Product)null)
                .Returns(products.ElementAt(3))
                .Returns((Product)null)
                .Returns((Product)null)
                .Returns((Product)null);
            //Act
            _productService.SaveProducts(products);
            //Assert
            _repoMock.Verify(x => x.Create(It.Is<IEnumerable<Product>>(x => x.Count() == productCount - 2)), Times.Once);
            _repoMock.Verify(x => x.Create(It.Is<IEnumerable<Product>>(x => x.Any(p =>
            p.HighPrice.ToString() != string.Empty &&
            p.LowPrice.ToString() != string.Empty &&
            p.TotalSum.ToString() != string.Empty &&
            p.TimesAdded == 1))));
            _repoMock.Verify(x => x.ReadByName(It.IsAny<string>()), Times.Exactly(productCount));

        }
        [DataTestMethod]
        [DynamicData(nameof(GetProducts), DynamicDataSourceType.Method)]
        public void update_products_which_exist_in_db(IEnumerable<Product> products)
        {
            //Arrange
            var productCount = products.Count();
            _repoMock.SetupSequence(x => x.ReadByName(It.IsAny<string>()))
                .Returns(new ElectricScooter() { 
                    Name = "Elektriskais skūteris Blaupunkt ESC505", 
                    Price = 550.56m,
                    HighPrice = 550.56m,
                    LowPrice = 550.56m,
                    TimesAdded = 1,
                    TotalSum = 550.56m,
                    Shop = ShopName.Shop1A })
                .Returns(new ElectricScooter(){
                    Name = "Elektriskais skūteris Razor E100 Blue",
                    Price = 110.56m,
                    HighPrice = 110.56m,
                    LowPrice = 110.56m,
                    TimesAdded = 1,
                    TotalSum = 110.56m,
                    Shop = ShopName.Shop1A});
            //Act
            _productService.SaveProducts(products);
            //Assert
            _repoMock.Verify(x => x.Update(It.Is<IEnumerable<Product>>(x => x.Count() == productCount - 5)), Times.Once);
            _repoMock.Verify(x => x.Update(It.Is<IEnumerable<Product>>(x => 
            x.ElementAt(0).Price == 220.56m &&
            x.ElementAt(0).LowPrice == 220.56m &&
            x.ElementAt(0).TotalSum == 550.56m + 220.56m &&
            x.ElementAt(0).TimesAdded == 2 &&
            x.ElementAt(0).AvgPrice == (550.56m + 220.56m) / 2)));
            _repoMock.Verify(x => x.Update(It.Is<IEnumerable<Product>>(x =>
            x.ElementAt(1).Price == 341.08m &&
            x.ElementAt(1).HighPrice == 341.08m &&
            x.ElementAt(1).TotalSum == 341.08m + 110.56m &&
            x.ElementAt(1).TimesAdded == 2 &&
            x.ElementAt(1).AvgPrice == (341.08m + 110.56m) / 2)));
        }
        [TestMethod]
        public void return_all_products_of_same_type()
        {
            _repoMock.Setup(x => x.Read()).Returns(It.IsAny<IEnumerable<ElectricScooter>>());
            _productService.GetProducts();
            _repoMock.Verify(x => x.Read(), Times.Once);
        }
        public static IEnumerable<object[]> GetProducts()
        {
        yield return new object[] { new List<ElectricScooter>() { 
            new ElectricScooter() { Name = "Elektriskais skūteris Blaupunkt ESC505", Price = 220.56m, Shop = ShopName.Shop1A }, 
            new ElectricScooter() { Name = "Elektriskais skūteris Razor E100 Blue", Price = 341.08m, Shop = ShopName.Shop1A },
            new ElectricScooter() { Name = "Elektr. skūteris Xiaomi Essential Lite", Price = 220.56m, Shop = ShopName.Shop1A },
            new ElectricScooter() { Name = "Motus Electric Scooter Scooty 8.5 Turquoise", Price = 341.08m, Shop = ShopName.Shop1A },
            new ElectricScooter() { Name = "Elektriskais skūteris Manta Saber MES605", Price = 156.25m, Shop = ShopName.Shop1A },
            new ElectricScooter() { Name = "Fiat F10K350PL", Price = 156.25m, Shop = ShopName.Shop1A },
            new ElectricScooter() { Name = "Fiat Electric Scooter F85K350PL Red", Price = 220.56m, Shop = ShopName.Shop1A },
            } };
        }
    }
}
