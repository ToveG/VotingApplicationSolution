namespace VotingApplication.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VotingApplication.Entities.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VotingApplication.Entities.DataContext context)
        {

            context.Questions.Add(new Entities.Question
            {
                Title = "Vilken serie är bäst?",
                Status = true,
                Answers = new List<ResponseOption>() {
                    new ResponseOption() {option = "Lost" },
                    new ResponseOption() { option = "Game of Thrones" }
                }
            });
            context.Questions.Add(new Question
            {
                Title = "Är du under 30 år?",
                Status = false,
                Answers = new List<ResponseOption>() {
                        new ResponseOption() {option = "Ja" },
                        new ResponseOption() { option = "Nej" }
                }
            });
            context.Questions.Add(new Question
            {
                Title = "Vad heter Sveriges stadsminister?",
                Status = true,
                Answers = new List<ResponseOption>()
                    {
                        new ResponseOption() {option = "Stefan Löven" },
                        new ResponseOption() {option = "Stefan Lövren" }
                    }
            });
            context.SaveChanges();
        }
    }
}












          
