namespace OnionMessenger.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageUserIdAuthorId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "UserId", newName: "AuthorId");
            RenameIndex(table: "dbo.Messages", name: "IX_UserId", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Messages", name: "IX_AuthorId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Messages", name: "AuthorId", newName: "UserId");
        }
    }
}
