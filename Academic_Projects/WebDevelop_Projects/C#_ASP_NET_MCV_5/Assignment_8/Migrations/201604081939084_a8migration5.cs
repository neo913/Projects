namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8migration5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Content = c.Binary(),
                        ContentType = c.String(),
                        StringId = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Artists_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artists_Id)
                .Index(t => t.Artists_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MediaItems", "Artists_Id", "dbo.Artists");
            DropIndex("dbo.MediaItems", new[] { "Artists_Id" });
            DropTable("dbo.MediaItems");
        }
    }
}
