using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;
using WebShopScraper.WebApi;

namespace WebShopScraper.Test
{
    [TestClass]
    public class ProductProcessorShould
    {
        private static Mock<IProductService<Product>> _serviceMock;
        private static ProductProcessor<Product> _productProcessor;

        [TestInitialize]
        public void Product()
        {
            _serviceMock = new Mock<IProductService<Product>>();
            _productProcessor = new ProductProcessor<Product>(_serviceMock.Object);
        }
        [DataTestMethod]
        [DynamicData(nameof(GetProducts), DynamicDataSourceType.Method)]
        public void return_products(IEnumerable<ElectricScooter> products)
        {
            // Arrange
            _serviceMock.Setup(x => x.GetProducts()).Returns(products);

            // Act
            var returnedProducts = _productProcessor.GetProducts();

            //Assert
            Assert.AreEqual(products.Count(), returnedProducts.Count());
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
