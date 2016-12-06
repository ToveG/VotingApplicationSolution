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
                Title = "Vilken serie �r b�st?",
                Status = true,
                Answers = new List<ResponseOption>() {
                    new ResponseOption() {option = "Lost" },
                    new ResponseOption() { option = "Game of Thrones" }
                }
            });
            context.Questions.Add(new Question
            {
                Title = "�r du under 30 �r?",
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
                        new ResponseOption() {option = "Stefan L�ven" },
                        new ResponseOption() {option = "Stefan L�vren" }
                    }
            });
            context.SaveChanges();
        }
    }
}












          
