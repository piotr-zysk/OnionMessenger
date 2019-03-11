namespace OnionMessenger.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Age", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Age");
        }
    }
}
