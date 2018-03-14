using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }

        public static List<SelectListItem> ActivityLevel
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Inactive", Value = "Inactive" },
                    new SelectListItem { Text = "Sedentary", Value = "Sedentary" },
                    new SelectListItem { Text = "Active", Value = "Active" },
                    new SelectListItem { Text = "Extremely Active", Value = "Extremely Active" }
                };
            }
        }
    }
}