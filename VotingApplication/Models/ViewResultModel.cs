using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApplication.Models
{
    public class ViewResultModel
    {
        public string question { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public double countOption1 { get; set; }
        public double countOption2 { get; set; }
        public string procentOption1 { get; set; }
        public string procentOption2 { get; set; }

    }
}