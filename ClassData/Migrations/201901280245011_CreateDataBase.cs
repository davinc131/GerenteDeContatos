namespace ClassData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContatoJuridico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categoria = c.Int(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Tipo = c.Int(nullable: false),
                        ContatoJur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContatoJuridico", t => t.ContatoJur_Id)
                .Index(t => t.ContatoJur_Id);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Departamento = c.Int(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Tipo = c.Int(nullable: false),
                        ContatoJuridico_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContatoJuridico", t => t.ContatoJuridico_Id)
                .Index(t => t.ContatoJuridico_Id);
            
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EndEmail = c.String(),
                        Departamento = c.Int(nullable: false),
                        Contato_Id = c.Int(),
                        ContatoJuridico_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contato", t => t.Contato_Id)
                .ForeignKey("dbo.ContatoJuridico", t => t.ContatoJuridico_Id)
                .Index(t => t.Contato_Id)
                .Index(t => t.ContatoJuridico_Id);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumTelefone = c.String(),
                        Departamento = c.Int(nullable: false),
                        Celular = c.Boolean(nullable: false),
                        Whatsapp = c.Boolean(nullable: false),
                        Contato_Id = c.Int(),
                        ContatoJuridico_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contato", t => t.Contato_Id)
                .ForeignKey("dbo.ContatoJuridico", t => t.ContatoJuridico_Id)
                .Index(t => t.Contato_Id)
                .Index(t => t.ContatoJuridico_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "ContatoJuridico_Id", "dbo.ContatoJuridico");
            DropForeignKey("dbo.Email", "ContatoJuridico_Id", "dbo.ContatoJuridico");
            DropForeignKey("dbo.Telefone", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.Email", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.Contato", "ContatoJuridico_Id", "dbo.ContatoJuridico");
            DropForeignKey("dbo.ContatoJuridico", "ContatoJur_Id", "dbo.ContatoJuridico");
            DropIndex("dbo.Telefone", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.Telefone", new[] { "Contato_Id" });
            DropIndex("dbo.Email", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.Email", new[] { "Contato_Id" });
            DropIndex("dbo.Contato", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.ContatoJuridico", new[] { "ContatoJur_Id" });
            DropTable("dbo.Telefone");
            DropTable("dbo.Email");
            DropTable("dbo.Contato");
            DropTable("dbo.ContatoJuridico");
        }
    }
}
