using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApplication.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ResponseOption> Answers;
        public bool Status { get; set; }
    }
}