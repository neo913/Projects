namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8migration4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tracks", "ContentType", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tracks", "ContentType", c => c.String());
        }
    }
}
