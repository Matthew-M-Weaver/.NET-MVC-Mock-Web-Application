﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkModel
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public Int64 Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public decimal MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public Int64 AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public string TempType { get; set; }
        public bool NeedsConverted { get; set; }
        public List<DailyForecast> FiveDayForecast { get; set; }
        public string ImageLocation { get { return ParkCode + ".jpg"; } }
    }
}