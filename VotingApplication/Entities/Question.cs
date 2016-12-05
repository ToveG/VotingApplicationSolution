using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApplication.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string title { get; set; }
        public ICollection<ResponseOption> answers;
        public bool Status { get; set; }


    }
}