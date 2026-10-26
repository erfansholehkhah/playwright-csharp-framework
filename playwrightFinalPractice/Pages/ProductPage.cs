using Microsoft.Playwright;
using playwrightFinalPractice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace playwrightFinalPractice.Pages
{
    public class ProductPage
    {


        private IPage Page;

        public ProductPage( IPage Page)
        {
            this.Page = Page;
            
        }

        private ILocator namefield => Page.GetByRole(AriaRole.Textbox, new() { Name = "Name" });
        private ILocator descriptionField => Page.GetByRole(AriaRole.Textbox, new() { Name = "Description" });
        private ILocator priceFiled => Page.Locator("#Price");

        private ILocator productTypeField => Page.Locator("#ProductType");

        private ILocator createButton => Page.GetByRole(AriaRole.Button, new() { Name = "Create" });


        public async Task CreateProductAsync (Product product) 
        {
            await namefield.FillAsync(product.Name);
            await descriptionField.FillAsync(product.Description);
            await priceFiled.FillAsync(product.Price.ToString());
            await productTypeField.SelectOptionAsync(((int)product.productType).ToString());

        } 

        public async Task ClickCreateAsync() 
        {
            await createButton.ClickAsync();
        }

       


    }

}
