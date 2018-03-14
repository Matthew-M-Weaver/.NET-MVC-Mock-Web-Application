using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class DailyForecast
    {
        public int Day { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Conditions { get; set; }

        public void ConvertToCelsius()
        {
            Low = (Low - 32) * (5 / 9);
            High = (High - 32) * (5 / 9);
        }

        public ConvertToFarenheit()
        {
            Low = Low * (9 / 5) + 32;
            High = High * (9 / 5) + 32;
        }
    }
}