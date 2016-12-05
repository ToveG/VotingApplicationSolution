namespace VotingApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VotingApplication.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VotingApplication.Models.DataContext context)
        {
            //context.Questions.AddOrUpdate(new Models.Question { status = Models.Status.Active, title = "Vad vill du ha till lunch." });



            //context.Inventories.AddOrUpdate(new Entities.Inventory { Category = Entities.Category.Övrigt, Ailes = "D", Shelf = 1 });


            //context.SaveChanges();

            //if (!context.ResponseOptions.Any(r => r.Id == 1))
            //{
            //  //  var store = new UserStore<ApplicationUser>(context);
            //    //var manager = new UserManager<ApplicationUser>(store);
            //    //var user = new ApplicationUser() { UserName = "lisa", Email = "lisa@gmail.com" };
            //    //manager.Create(user, "lisa123");
            //}



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
