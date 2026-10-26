

using Microsoft.Playwright;
using playwrightFinalPractice.Config;

namespace playwrightFinalPractice.Driver
{
    public class PlaywrighDriverInitializer : IPlaywrighDriverInitializer
    {
        public const float DEFAULT_TIMEOUT = 30F;
        public async Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.TimeOut, testSettings.Headless,
                testSettings.SlowMo);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }

        public async Task<IBrowser> GetFireFoxDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.TimeOut, testSettings.Headless,
                testSettings.SlowMo);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Firefox, options);
        }

        public async Task<IBrowser> GetEdgeDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.TimeOut, testSettings.Headless,
                testSettings.SlowMo);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Edge, options);
        }

        public async Task<IBrowser> GetWebKitDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.TimeOut, testSettings.Headless,
                testSettings.SlowMo);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Webkit, options);
        }

        public async Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings)
        {
            var options = GetParameters(testSettings.Args, testSettings.TimeOut, testSettings.Headless,
                testSettings.SlowMo);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }

        private async Task<IBrowser> GetBrowserAsync(DriverType driverType, BrowserTypeLaunchOptions options)
        {
            var playwright = await Playwright.CreateAsync();
            return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
        }

        private BrowserTypeLaunchOptions GetParameters(string[]? args, float? timeout = DEFAULT_TIMEOUT,
            bool? headeless = false, float? slowmo = null)
        {
            return new BrowserTypeLaunchOptions
            {
                Args = args,
                Timeout = ToMillisecond(timeout),
                Headless = headeless,
                SlowMo = slowmo
            };
        }

        private static float? ToMillisecond(float? seconds)
        {
            return seconds * 1000;
        }
    }
}
