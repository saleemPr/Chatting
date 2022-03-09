namespace Chatting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registers", "Image");
        }
    }
}
