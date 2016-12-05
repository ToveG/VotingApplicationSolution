using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace VotingApplication.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<Result> Results { get; set; }
        public DbSet<ResponseOption> ResponseOptions { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DataContext() 
            :base ("name = Voting")
        {

        }

    }
}