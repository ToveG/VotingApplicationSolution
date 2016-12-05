namespace VotingApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedStatusToBool : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResponseOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        option = c.String(),
                        question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.question_Id)
                .Index(t => t.question_Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        question_Id = c.Int(),
                        responseOption_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.question_Id)
                .ForeignKey("dbo.ResponseOptions", t => t.responseOption_Id)
                .Index(t => t.question_Id)
                .Index(t => t.responseOption_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "responseOption_Id", "dbo.ResponseOptions");
            DropForeignKey("dbo.Results", "question_Id", "dbo.Questions");
            DropForeignKey("dbo.ResponseOptions", "question_Id", "dbo.Questions");
            DropIndex("dbo.Results", new[] { "responseOption_Id" });
            DropIndex("dbo.Results", new[] { "question_Id" });
            DropIndex("dbo.ResponseOptions", new[] { "question_Id" });
            DropTable("dbo.Results");
            DropTable("dbo.ResponseOptions");
            DropTable("dbo.Questions");
        }
    }
}
