using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Utilities.Helpers
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
