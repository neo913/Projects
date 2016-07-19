namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Profile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Profile");
        }
    }
}
