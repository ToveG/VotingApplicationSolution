using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApplication.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public Question question { get; set; }
        public ResponseOption responseOption { get; set; }
    }
}