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
        private IParkDAL parkDAL;
        private IDailyForecastDAL dailyForecastDAL;
        private ISurveyDAL surveyDAL;
        private ISurveyResultDAL surveyResultDAL;

        public HomeController(IParkDAL parkDAL, IDailyForecastDAL dailyForecastDAL, ISurveyDAL surveyDAL, ISurveyResultDAL surveyResultDAL)
        {
            this.parkDAL = parkDAL;
            this.dailyForecastDAL = dailyForecastDAL;
            this.surveyDAL = surveyDAL;
            this.surveyResultDAL = surveyResultDAL;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<ParkModel> parks = parkDAL.GetIndexInformation();
            return View(parks);
        }

        public ActionResult Detail(ParkModel park)
        {
            bool conversion = park.NeedsConverted;
            string tempType = park.TempType;
            park = parkDAL.GetDetailInformation(park);
            park.FiveDayForecast = dailyForecastDAL.GetDailyForecasts(park);
            if (conversion)
            {
                if (tempType == "C")
                {
                    foreach (DailyForecast forecast in park.FiveDayForecast)
                    {
                        forecast.High = (int)(forecast.High * 1.8 + 32);
                        forecast.Low = (int)(forecast.Low * 1.8 + 32);

                    }
                    park.TempType = "F";
                }
                else
                {
                    foreach (DailyForecast forecast in park.FiveDayForecast)
                    {
                        forecast.High = (int)((forecast.High - 32) * .5556);
                        forecast.Low = (int)((forecast.Low - 32) * .5556);
                    }
                    park.TempType = "C";
                }
            }
            return View(park);
        }

        public ActionResult Survey()
        {
            return View();
        }

        public ActionResult SurveyResults()
        {
            List<SurveyResult> parkRankings = surveyResultDAL.GetSurveyResults();
            return View(parkRankings);
        }

        [HttpPost]
        public ActionResult Commit(SurveyModel survey)
        {
            surveyDAL.CommitSurvey(survey);
            return RedirectToAction("SurveyResults");
        }
    }
}