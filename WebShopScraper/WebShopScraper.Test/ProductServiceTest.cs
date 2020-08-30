using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Test
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void ProductExists_Returns_Product_if_it_exists()
        {
            //Arrange
            var product = new ElectricScooter() { Name = "Elektriskais skūteris Blaupunkt ESC505", Price = 220.56m, Shop = ShopName.Shop1A };
            var repoMock = new Mock<IRepository<Product>>();
            var productService = new ProductService<Product>(repoMock.Object);
            repoMock.Setup(_ => _.ReadByName(It.IsAny<string>())).Returns(product);
            //Act
            var returnedProduct = productService.ProductExists(product);
            //Assert
            Assert.AreEqual(product, returnedProduct);
        }

        [TestMethod]
        public void ProductExists_Returns_null_if_product_does_not_exist()
        {
            //Arrange
            ElectricScooter product = new ElectricScooter() { Name = "Elektriskais skūteris Blaupunkt ESC505", Price = 220.56m, Shop = ShopName.Shop1A };
            ElectricScooter nullProduct = null;
            var repoMock = new Mock<IRepository<Product>>();
            var productServiceMock = new ProductService<Product>(repoMock.Object);
            repoMock.Setup(_ => _.ReadByName(It.IsAny<string>())).Returns(nullProduct);
            //Act
            var returnedProduct = productServiceMock.ProductExists(product);
            //Assert
            Assert.IsNull(returnedProduct);
        }
        [TestMethod]
        public void ProductExists_Returns_null_if_there_same_product_from_different_shops()
        {
            //Arrange
            ElectricScooter product1 = new ElectricScooter() { Name = "Elektriskais skūteris Blaupunkt ESC505", Price = 220.56m, Shop = ShopName.Shop1A };
            ElectricScooter product2 = new ElectricScooter() { Name = "Elektriskais skūteris Blaupunkt ESC505", Price = 220.56m, Shop = ShopName.Shop220 };
            var repoMock = new Mock<IRepository<Product>>();
            var productServiceMock = new ProductService<Product>(repoMock.Object);
            repoMock.Setup(_ => _.ReadByName(It.IsAny<string>())).Returns(product1);
            //Act
            var returnedProduct = productServiceMock.ProductExists(product2);
            //Assert
            Assert.IsNull(returnedProduct);
        }
        //[TestMethod]
        //public void SetHighPrice_Sets_new_high_price_if_current_price_is_higher()
        //{
        //    ElectricScooter product = new ElectricScooter() { Name = "Elektriskais skūteris Blaupunkt ESC505", Price = 220.56m, Shop = ShopName.Shop1A };
        //    var repoMock = new Mock<IRepository<Product>>();
        //    var productServiceMock = new ProductService<Product>(repoMock.Object);
        //    repoMock.Setup(x => x.ReadByName(It.IsAny<string>())).Returns(product);
            
        //}
        //[TestMethod]
        //[DynamicData(nameof(GetDistinctProducts), DynamicDataSourceType.Method)]
        //public void GetDistinctProducts_Returns_products_which_are_not_in_Db(IEnumerable<ElectricScooter> products)
        //{
        //    var productServiceMock = new Mock<IProductService<Product>>();
        //    var actual = productServiceMock.Object.FilterProducts(products);
        //    var expected = GetRepositoryProducts();

        //    Assert.

        //}

        public static IEnumerable<object[]> GetDistinctProducts()
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

            //yield return new object[] { new List<ElectricScooter>() { 
            //    new ElectricScooter() { Name = "Fiat F10K350PL", Price = 156.25m, Shop = ShopName.Shop1A }, 
            //    new ElectricScooter() { Name = "Elektr. skūteris Xiaomi Essential Lite", Price = 809.72m, Shop = ShopName.Shop1A },
            //    new ElectricScooter() { Name = "Fiat Electric Scooter F85K350PL Red", Price = 220.56m, Shop = ShopName.Shop1A },
            //    new ElectricScooter() { Name = "Motus Electric Scooter Scooty 8.5 Turquoise", Price = 341.08m, Shop = ShopName.Shop1A }
            //} };
            //yield return new object[] { new List<ElectricScooter>() { 
            //    new ElectricScooter() { Name = "Motus Electric Scooter Scooty 8.5 Turquoise", Price = 56.63m, Shop = ShopName.Shop1A }, 
            //    new ElectricScooter() { Name = "Elektriskais skūteris Razor E100 Blue", Price = 409.47m, Shop = ShopName.Shop1A } ,
            //    new ElectricScooter() { Name = "Elektr. skūteris Xiaomi Essential Lite", Price = 220.56m, Shop = ShopName.Shop1A },
            //    new ElectricScooter() { Name = "Motus Electric Scooter Scooty 8.5 Turquoise", Price = 341.08m, Shop = ShopName.Shop1A }
            //} };
        }
        public static IEnumerable<object[]> GetRepositoryProducts()
        {
            yield return new object[] { new List<ElectricScooter>() {
                new ElectricScooter() { Name = "Elektriskais skūteris Blaupunkt ESC505", Price = 220.56m, Shop = ShopName.Shop1A },
                new ElectricScooter() { Name = "Elektr. skūteris Xiaomi Essential Lite", Price = 220.56m, Shop = ShopName.Shop1A },
                new ElectricScooter() { Name = "Elektriskais skūteris Manta Saber MES605", Price = 156.25m, Shop = ShopName.Shop1A },
                new ElectricScooter() { Name = "BMW F10K350PL", Price = 156.25m, Shop = ShopName.Shop1A },
                new ElectricScooter() { Name = "Owermax Electric Scooter X-roister 30", Price = 220.56m, Shop = ShopName.Shop1A },
            } };

            //yield return new object[] { new List<ElectricScooter>() { 
            //    new ElectricScooter() { Name = "Fiat F10K350PL", Price = 156.25m, Shop = ShopName.Shop1A }, 
            //    new ElectricScooter() { Name = "Elektr. skūteris Xiaomi Essential Lite", Price = 809.72m, Shop = ShopName.Shop1A },
            //    new ElectricScooter() { Name = "Fiat Electric Scooter F85K350PL Red", Price = 220.56m, Shop = ShopName.Shop1A },
            //    new ElectricScooter() { Name = "Motus Electric Scooter Scooty 8.5 Turquoise", Price = 341.08m, Shop = ShopName.Shop1A }
            //} };
            //yield return new object[] { new List<ElectricScooter>() { 
            //    new ElectricScooter() { Name = "Motus Electric Scooter Scooty 8.5 Turquoise", Price = 56.63m, Shop = ShopName.Shop1A }, 
            //    new ElectricScooter() { Name = "Elektriskais skūteris Razor E100 Blue", Price = 409.47m, Shop = ShopName.Shop1A } ,
            //    new ElectricScooter() { Name = "Elektr. skūteris Xiaomi Essential Lite", Price = 220.56m, Shop = ShopName.Shop1A },
            //    new ElectricScooter() { Name = "Motus Electric Scooter Scooty 8.5 Turquoise", Price = 341.08m, Shop = ShopName.Shop1A }
            //} };
        }

    }
}
