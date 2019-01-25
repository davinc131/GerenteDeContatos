namespace ClassData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationTelefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Telefones", "Celular", c => c.Boolean(nullable: false));
            AddColumn("dbo.Telefones", "Whatsapp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Telefones", "Whatsapp");
            DropColumn("dbo.Telefones", "Celular");
        }
    }
}
