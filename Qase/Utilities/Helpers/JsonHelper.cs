using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;

namespace Core.Utilities.Helpers
{
    public class JsonHelper
    {
        public static string GetBasePath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string GetJson(string fileName)
        {
            return File.ReadAllText(GetBasePath() + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar + fileName);
        }

        public static JObject FromJson(string fileName)
        {
            return JsonConvert.DeserializeObject<JObject>(GetJson(fileName));
        }
    }
}
