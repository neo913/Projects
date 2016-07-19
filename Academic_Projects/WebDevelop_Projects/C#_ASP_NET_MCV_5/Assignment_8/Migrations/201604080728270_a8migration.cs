namespace Assignment_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoleClaims");
        }
    }
}
