
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace playwrightFinalPractice.Config
{
    public static class ConfigReader
    {
        public static TestSettings ReadConfig () 
        {
            var path = Path.Combine(
     Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
     "appsettings.json");

            var configFile = File.ReadAllText(path);
            var jsonSerializerSettng = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            jsonSerializerSettng.Converters.Add(new JsonStringEnumConverter());
            return System.Text.Json.JsonSerializer.Deserialize<TestSettings>(configFile,jsonSerializerSettng);

        }

    }
}
