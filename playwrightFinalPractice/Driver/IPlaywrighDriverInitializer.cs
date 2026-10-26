using Microsoft.Playwright;
using playwrightFinalPractice.Config;

namespace playwrightFinalPractice.Driver
{
    public interface IPlaywrighDriverInitializer
    {
        Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetEdgeDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetFireFoxDriverAsync(TestSettings testSettings);
        Task<IBrowser> GetWebKitDriverAsync(TestSettings testSettings);
    }
}