namespace ClassData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropWhatsapp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contatoes", "Whatsapp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contatoes", "Whatsapp", c => c.Boolean(nullable: false));
        }
    }
}
