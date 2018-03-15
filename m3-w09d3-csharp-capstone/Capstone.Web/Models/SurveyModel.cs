using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        [Required]
        public string ParkCode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ActivityLevel { get; set; }
    }
}