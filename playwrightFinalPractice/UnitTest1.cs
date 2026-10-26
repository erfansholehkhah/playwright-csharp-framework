using AutoFixture.NUnit3;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;
using playwrightFinalPractice.Config;
using playwrightFinalPractice.Driver;
using playwrightFinalPractice.Models;
using playwrightFinalPractice.Pages;

namespace playwrightFinalPractice
{
    public class Tests
    {


        private PlaywrightDriver _driver;
        private IPlaywrighDriverInitializer _playwrighDriverInitializer;   // was PlaywrighDriverInitializer
        private IServiceProvider _serviceProvider;
        [SetUp]
        public void Setup()
        {
            //string baseUrl = "https://eaapp.somee.com/";

            var services = new ServiceCollection();
            new StartUp().ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            _driver = _serviceProvider.GetRequiredService<PlaywrightDriver>();


        }

        [Test]
        public async Task Test1()
        {
            string baseUrl = "http://localhost:5001/";
            var Page = await _driver.Page;
            await Page.GotoAsync(baseUrl);


        }

        [Test]
        public async Task Test2()
        {

            string baseUrl = "http://localhost:5001/";
            var Page = await _driver.Page;
            await Page.GotoAsync(baseUrl);


        }


        [TestCase("Speaker", "Gaming Spekaer", 2000, 3)]
        [TestCase("USB", "USB 3.0 ", 3000, 1)]
        [TestCase("Webcam", "Camera", 4000, 3)]
        [TestCase("Wires", "Cables for life", 2000, 2)]


        //public async Task Test3(string name, string description, int price, int productType)
        //{
        //    var Page = await _driver.Page;
        //    await Page.GotoAsync("http://localhost:5001/");
        //    ProductListPage productListPage = new ProductListPage(Page);
        //    ProductPage productPage = new ProductPage(Page);
        //    await productListPage.CreatProductAsync();
        //    await productPage.CreateProductAsync(name, description, price, productType);
        //    //await Page.PauseAsync();
        //    await productPage.ClickCreateAsync();

        //    await productListPage.ClickProductFromList(name);
        //    var element = productListPage.IsProductCreated(name);
        //    //await Assertions.Expect(productListPage.GetProduct("Speaker")).ToBeVisibleAsync();

        //}

        [TestCase("Speaker", "Gaming Spekaer", 2000, 3)]
        [TestCase("USB", "USB 3.0 ", 3000, 1)]
        [TestCase("Webcam", "Camera", 4000, 3)]
        [TestCase("Wires", "Cables for life", 2000, 2)]


        public async Task TestWithconceretTypes(string name, string description, int price, int productType)
        {
            var Page = await _driver.Page;
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                productType = (Product.ProductType)productType
            };
            await Page.GotoAsync("http://localhost:5001/");
            ProductListPage productListPage = new ProductListPage(Page);
            ProductPage productPage = new ProductPage(Page);
            await productListPage.CreatProductAsync();
            await productPage.CreateProductAsync(product);
            //await Page.PauseAsync();
            await productPage.ClickCreateAsync();

            await productListPage.ClickProductFromList(product.Name);
            var element = productListPage.IsProductCreated(product.Name);
            //await Assertions.Expect(productListPage.GetProduct("Speaker")).ToBeVisibleAsync();

        }


        [Test,AutoData]
        public async Task TestWithAutoData(Product product)
        {
            var Page = await _driver.Page;
          
            await Page.GotoAsync("http://localhost:5001/");
            ProductListPage productListPage = new ProductListPage(Page);
            ProductPage productPage = new ProductPage(Page);
            await productListPage.CreatProductAsync();
            await productPage.CreateProductAsync(product);
            //await Page.PauseAsync();
            await productPage.ClickCreateAsync();

            await productListPage.ClickProductFromList(product.Name);
            var element = productListPage.IsProductCreated(product.Name);
            //await Assertions.Expect(productListPage.GetProduct("Speaker")).ToBeVisibleAsync();

        }
        [TearDown]
        public async Task TearDown()
        {
            
            var browser = await _driver.Browser;
            await browser.CloseAsync();
            await browser.DisposeAsync();
            (_serviceProvider as IDisposable)?.Dispose();

        }
    }
}
