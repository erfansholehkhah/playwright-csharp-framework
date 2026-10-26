using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace playwrightFinalPractice.Pages
{
    public class ProductListPage
    {
        private readonly IPage Page;

       

        public ProductListPage(IPage Page)
        {
             this.Page = Page;
        }

        private ILocator productListLink => Page.GetByRole(AriaRole.Link, new() { Name = "Product" });
        private ILocator createButton => Page.GetByRole(AriaRole.Link, new() { Name = "Create" });
        //private ILocator row => Page.GetByRole(AriaRole.Row, new PageGetByRoleOptions() { Name = "Speaker" });


        public async Task CreatProductAsync () 
        {
            await productListLink.ClickAsync();
            await createButton.ClickAsync();
        }

        public async Task ClickProductFromList(string name) 
        {
           await Page.GetByRole(AriaRole.Row, new PageGetByRoleOptions() { Name = name })
                .GetByRole(AriaRole.Link, new LocatorGetByRoleOptions() { Name = "Details" }).ClickAsync();
        }

       

        public async Task IsProductCreated(string product)
        {

            var locator =  Page.GetByText(product);
            await Assertions.Expect(locator).ToBeVisibleAsync();
        }

        public ILocator GetProduct(string product) => Page.GetByText(product);

    }
}
