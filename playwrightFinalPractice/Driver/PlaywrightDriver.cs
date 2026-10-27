using Microsoft.Playwright;
using playwrightFinalPractice.Config;


namespace playwrightFinalPractice.Driver
{
    public class PlaywrightDriver
    {

        private readonly AsyncTask<IBrowser> _browser;
        private readonly AsyncTask <IBrowserContext> _broserContext;
        private readonly TestSettings _testSettings;
        private readonly IPlaywrighDriverInitializer _playwrighDriverInitializer;
        private readonly AsyncTask<IPage>  _page;
        private readonly AsyncTask<IAPIRequestContext> _apiRequestContext;

        public PlaywrightDriver(TestSettings testSettings, IPlaywrighDriverInitializer playwrighDriverInitializer) // CONSTRUCTOR CAN NOT BE ASYNC AT ALL 
        {
            _testSettings = testSettings;
            _playwrighDriverInitializer = playwrighDriverInitializer;
            _browser = new AsyncTask<IBrowser>(InitializePlaywrightAsync);
            // REMEMBER , THIS CONSTRUCTOR IS NOT AN ASYNC MEHTOD , BUT INITILIALIZER IS 
            // we can user mthod grouping 
            _broserContext =  new AsyncTask <IBrowserContext>(CreateBrowserContext);
            _page =  new AsyncTask<IPage> (CreatePageAsync);
            _apiRequestContext = new AsyncTask<IAPIRequestContext>(CreateApiContext);

           

        }


        public Task < IPage> Page => _page.Value;
        public Task< IBrowser> Browser => _browser.Value;

        public Task< IBrowserContext> BrowserContext => _broserContext.Value;
        // exposing 
        public Task<IAPIRequestContext> ApiRequestContext => _apiRequestContext.Value;
        

        private async Task<IBrowser> InitializePlaywrightAsync()
        {
            return _testSettings.DriverType switch
            {
                DriverType.Chromium => await _playwrighDriverInitializer.GetChromiumDriverAsync(_testSettings),
                DriverType.Chrome => await _playwrighDriverInitializer.GetChromeDriverAsync(_testSettings),
                DriverType.Edge => await _playwrighDriverInitializer.GetEdgeDriverAsync(_testSettings),
                DriverType.Firefox => await _playwrighDriverInitializer.GetFireFoxDriverAsync(_testSettings),
                _ => await _playwrighDriverInitializer.GetChromeDriverAsync(_testSettings),
            };
        }

        private async Task <IAPIRequestContext>CreateApiContext() 
        {
            var playwright  = await Playwright.CreateAsync();
            return await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL =  _testSettings.ApplicationApiUrl,
                IgnoreHTTPSErrors = true,

            });
        }

        private async Task<IBrowserContext> CreateBrowserContext()
        {
            
            return await (await _browser).NewContextAsync();

        }

       

        private async Task  <IPage> CreatePageAsync()
        {
   
           return await (await _broserContext).NewPageAsync();

            
        }
    }
}
