using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qase.Utilities
{
    public  class Endpoints
    {
        public static readonly string CREATE_PROJECT = "v1/project";
        public static readonly string GET_PROJECT = "v1/project/{code}";
        public static readonly string CREATE_SUITE = "v1/suite/{code}";
        public static readonly string GET_SUITE = "v1/suite/{code}/{id}";
    }
}
