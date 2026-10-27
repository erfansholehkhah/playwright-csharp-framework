using playwrightFinalPractice.Config;
using playwrightFinalPractice.Driver;
using playwrightFinalPractice.Models;
using System.Text.Json;


namespace playwrightFramework.APITest
{
    public class ProductsApiTest
    {
        private PlaywrightDriver playwrightDriver;
        [SetUp]
        public void Setup()
        {
            var testSettings = ConfigReader.ReadConfig();
            var initializer = new PlaywrighDriverInitializer();
            playwrightDriver = new PlaywrightDriver(testSettings, initializer);
        }


        [Test]
        public async Task GetProducts()
        {
            var productResposne = await (await playwrightDriver.ApiRequestContext).GetAsync("Product/GetProductById/1");
            var data = await productResposne.TextAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            //var product  = data?.Deserialize <>
            var product = JsonSerializer.Deserialize<Product>(data, options);
            TestContext.WriteLine("Product name: " + product.Name);
            Assert.That(productResposne.Status, Is.EqualTo(200));



        }

        [Test]
        public async Task DeletProductAsync()
        {
            var deletResponse = await (await playwrightDriver.ApiRequestContext).DeleteAsync("Product/Delete/1");
            Assert.That(deletResponse.Status, Is.EqualTo(200));   // or 204 — see note

            // 2) try to fetch it again
            var getResponse = await (await playwrightDriver.ApiRequestContext)
                .GetAsync("Product/GetProductById/1");

            // assert it's gone (not found)
            Assert.That(getResponse.Status, Is.EqualTo(404));
        }
    }
}
