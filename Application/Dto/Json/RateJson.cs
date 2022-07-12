using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Json
{
    public class RateJson
    {
        public string code { get; set; }
        public List<RateJsonValue> rates { get; set; }

        public class RateJsonValue
        {
            public string effectiveDate { get; set; }
            public double mid { get; set; }
        }
    }
}
