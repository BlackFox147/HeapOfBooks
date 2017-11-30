namespace CodeHeapOfBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30112017SampleMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateСreation = c.DateTime(nullable: false),
                        DateLastChange = c.DateTime(nullable: false),
                        FilePath = c.String(),
                        CollectionId = c.Int(),
                        Author = c.String(),
                        Series = c.String(),
                        NumberInTheSeries = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collections", t => t.CollectionId)
                .Index(t => t.CollectionId);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateСreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Information = c.String(),
                        DateСreation = c.DateTime(nullable: false),
                        DateLastChange = c.DateTime(nullable: false),
                        DocumentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .Index(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commits", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "CollectionId", "dbo.Collections");
            DropIndex("dbo.Commits", new[] { "DocumentId" });
            DropIndex("dbo.Documents", new[] { "CollectionId" });
            DropTable("dbo.Commits");
            DropTable("dbo.Collections");
            DropTable("dbo.Documents");
        }
    }
}
