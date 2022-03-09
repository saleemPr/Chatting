﻿namespace Chatting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registers", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registers", "Status");
        }
    }
}
