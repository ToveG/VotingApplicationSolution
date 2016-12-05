using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VotingApplication.Models
{
    public class CreateQuestion
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Title { get; set; }

        public bool Status { get; set; }
    }
}