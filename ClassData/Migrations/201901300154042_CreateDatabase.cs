namespace ClassData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
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
                        Auditoria_Id = c.Int(),
                        ContatoJuridico_Id = c.Int(),
                        OrganizacaoSocial_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContatoJuridico", t => t.Auditoria_Id)
                .ForeignKey("dbo.ContatoJuridico", t => t.ContatoJuridico_Id)
                .ForeignKey("dbo.ContatoJuridico", t => t.OrganizacaoSocial_Id)
                .Index(t => t.Auditoria_Id)
                .Index(t => t.ContatoJuridico_Id)
                .Index(t => t.OrganizacaoSocial_Id);
            
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
            DropForeignKey("dbo.ContatoJuridico", "OrganizacaoSocial_Id", "dbo.ContatoJuridico");
            DropForeignKey("dbo.ContatoJuridico", "ContatoJuridico_Id", "dbo.ContatoJuridico");
            DropForeignKey("dbo.Email", "ContatoJuridico_Id", "dbo.ContatoJuridico");
            DropForeignKey("dbo.Telefone", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.Email", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.Contato", "ContatoJuridico_Id", "dbo.ContatoJuridico");
            DropForeignKey("dbo.ContatoJuridico", "Auditoria_Id", "dbo.ContatoJuridico");
            DropIndex("dbo.Telefone", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.Telefone", new[] { "Contato_Id" });
            DropIndex("dbo.Email", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.Email", new[] { "Contato_Id" });
            DropIndex("dbo.Contato", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.ContatoJuridico", new[] { "OrganizacaoSocial_Id" });
            DropIndex("dbo.ContatoJuridico", new[] { "ContatoJuridico_Id" });
            DropIndex("dbo.ContatoJuridico", new[] { "Auditoria_Id" });
            DropTable("dbo.Telefone");
            DropTable("dbo.Email");
            DropTable("dbo.Contato");
            DropTable("dbo.ContatoJuridico");
        }
    }
}
