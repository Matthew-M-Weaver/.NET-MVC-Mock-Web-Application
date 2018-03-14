using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        IParkDAL ParkDAL;
        IDailyForecastDAL dailyForecastDAL;
        ISurveyDAL surveyDAL;
        ISurveyResultDAL surveyResultDAL;

        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}