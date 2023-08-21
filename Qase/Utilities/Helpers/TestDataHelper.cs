
using BusinessObject.Models;

namespace Core.Utilities.Helpers
{
    public class TestDataHelper
    {
        public static Suite CreateSuite(string fileName)
        {
            return JsonHelper.FromJson(fileName).ToObject<Suite>();
        }
    }
}
