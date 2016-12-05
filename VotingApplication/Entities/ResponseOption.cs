using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApplication.Entities
{
    public class ResponseOption
    {
        public int Id { get; set; }
        public string option { get; set; }
        public virtual Question question { get; set; }

        public int questionId { get; set; }
    }
}