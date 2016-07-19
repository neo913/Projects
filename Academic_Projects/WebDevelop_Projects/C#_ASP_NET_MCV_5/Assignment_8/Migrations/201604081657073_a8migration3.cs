namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "Content", c => c.Binary());
            AddColumn("dbo.Tracks", "ContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "ContentType");
            DropColumn("dbo.Tracks", "Content");
        }
    }
}
