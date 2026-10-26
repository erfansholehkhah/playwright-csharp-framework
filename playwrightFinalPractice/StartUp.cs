

using Microsoft.Extensions.DependencyInjection;
using playwrightFinalPractice.Config;
using playwrightFinalPractice.Driver;
using System.Xml.Serialization;

namespace playwrightFinalPractice
{
    public class StartUp
    {
        public void ConfigureServices (IServiceCollection services) 
            
        {

            services.AddSingleton(ConfigReader.ReadConfig());
            services.AddScoped <IPlaywrighDriverInitializer,PlaywrighDriverInitializer>();
            services.AddScoped<PlaywrightDriver>();
        }
    }
}
