using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApplication.Models
{
    public class ViewResult
    {
        public string question { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public int countOption1 { get; set; }
        public int countOption2 { get; set; }
        public int procentOption1 { get; set; }
        public int procentOption2 { get; set; }

    }
}