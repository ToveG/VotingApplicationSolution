using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApplication.Entities
{
    public static class DataContextExtention
    {
        public static void SeedWithDefaultData(this DataContext context)
        {
            if (context.Questions.Any())
            {
                return;
            }

            var questions = new List<Question>()
            {
                new Question()
                {
                    Title = "Vilken serie är bäst?",
                    Status = true,
                    Answers = new List<ResponseOption>() { new ResponseOption() { option = "Lost" }, new ResponseOption() { option = "Game of Thrones"} }
                },
                new Question()
                {
                    Title = "Är du under 30 år?",
                    Status = false,
                    Answers = new List<ResponseOption>() { new ResponseOption() { option = "Ja" }, new ResponseOption() { option = "Nej"} }
                },
                new Question()
                {
                    Title = "Vad heter Sveriges stadsminister?",
                    Status = true,
                    Answers = new List<ResponseOption>() { new ResponseOption() { option = "Stefan Löven" }, new ResponseOption() { option = "Stefan Lövren"} }
                },
            };

            context.Questions.AddRange(questions);
            context.SaveChanges();
        }

    }
}