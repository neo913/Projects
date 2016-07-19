namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "description");
        }
    }
}
