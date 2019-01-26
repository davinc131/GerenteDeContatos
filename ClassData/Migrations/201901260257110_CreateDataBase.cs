namespace ClassData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContatoJuridicoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categoria = c.Int(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Tipo = c.Int(nullable: false),
                        ContatoJuridico_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContatoJuridicoes", t => t.ContatoJuridico_Id)
                .Index(t => t.ContatoJuridico_Id);
            
            CreateTable(
                "dbo.Contatoes",
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
                .ForeignKey("dbo.ContatoJuridicoes", t => t.ContatoJuridico_Id)
                .Index(t => t.ContatoJuridico_Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EndEmail = c.String(),
                        Departamento = c.Int(nullable: false),
                        Contato_Id = c.Int(),
                        ContatoJuridico_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contatoes", t => t.Contato_Id)
                .ForeignKey("dbo.ContatoJuridicoes", t => t.ContatoJuridico_Id)
                .Index(t => t.Contato_Id)
                .Index(t => t.ContatoJuridico_Id);
            
            CreateTable(
                "dbo.Telefones",
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
                .ForeignKey("dbo.Contatoes", t => t.Contato_Id)
                .ForeignKey("dbo.ContatoJuridicoes", t => t.ContatoJuridico_Id)
                .Index(t => t.Contato_Id)
                .Index(t => t.ContatoJuridico_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContatoJuridicoes", "ContatoJuridico_Id", "dbo.ContatoJuridicoes");
            DropForeignKey("dbo.Telefones", "ContatoJuridico_Id", "dbo.ContatoJuridicoes");
            DropForeignKey("dbo.Emails", "ContatoJuridico_Id", "dbo.ContatoJuridicoes");
            DropForeignKey("dbo.Contatoes", "ContatoJuridico_Id", "dbo.ContatoJuridicoes");
            DropForeignKey("dbo.Telefones", "Contato_Id", "dbo.Contatoes");
            DropForeignKey("dbo.Emails", "Contato_Id", "dbo.Contatoes");
            DropIndex("dbo.Telefones", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.Telefones", new[] { "Contato_Id" });
            DropIndex("dbo.Emails", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.Emails", new[] { "Contato_Id" });
            DropIndex("dbo.Contatoes", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.ContatoJuridicoes", new[] { "ContatoJuridico_Id" });
            DropTable("dbo.Telefones");
            DropTable("dbo.Emails");
            DropTable("dbo.Contatoes");
            DropTable("dbo.ContatoJuridicoes");
        }
    }
}
