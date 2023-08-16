using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qase.Models;

namespace Qase.Utilities.Helpers
{
    public class TestDataHelper
    {
        public static Suite CreateSuite(string fileName)
        {
            return JsonHelper.FromJson(fileName).ToObject<Suite>();
        }

        
    }
}
