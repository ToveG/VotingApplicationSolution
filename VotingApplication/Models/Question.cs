using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApplication.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string title { get; set; }
        public List<ResponseOption> answer;
        public bool Status { get; set; }


    }
}