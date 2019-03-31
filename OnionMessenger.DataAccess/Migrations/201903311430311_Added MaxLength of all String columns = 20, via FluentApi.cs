namespace OnionMessenger.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaxLengthofallStringcolumns20viaFluentApi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Login", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
        }
    }
}
