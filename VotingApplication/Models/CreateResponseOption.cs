using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VotingApplication.Models
{
    public class CreateResponseOption
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string option { get; set; }
        
    }
}