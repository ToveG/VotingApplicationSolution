namespace VotingApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResponseOptions", "question_Id", "dbo.Questions");
            DropIndex("dbo.ResponseOptions", new[] { "question_Id" });
            RenameColumn(table: "dbo.ResponseOptions", name: "question_Id", newName: "questionId");
            AlterColumn("dbo.Questions", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ResponseOptions", "option", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ResponseOptions", "questionId", c => c.Int(nullable: false));
            CreateIndex("dbo.ResponseOptions", "questionId");
            AddForeignKey("dbo.ResponseOptions", "questionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResponseOptions", "questionId", "dbo.Questions");
            DropIndex("dbo.ResponseOptions", new[] { "questionId" });
            AlterColumn("dbo.ResponseOptions", "questionId", c => c.Int());
            AlterColumn("dbo.ResponseOptions", "option", c => c.String());
            AlterColumn("dbo.Questions", "Title", c => c.String());
            RenameColumn(table: "dbo.ResponseOptions", name: "questionId", newName: "question_Id");
            CreateIndex("dbo.ResponseOptions", "question_Id");
            AddForeignKey("dbo.ResponseOptions", "question_Id", "dbo.Questions", "Id");
        }
    }
}
