namespace ClassData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContatoJuridicoes", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.ContatoJuridicoes", new[] { "Categoria_Id" });
            AddColumn("dbo.ContatoJuridicoes", "Categoria", c => c.Int(nullable: false));
            DropColumn("dbo.ContatoJuridicoes", "Categoria_Id");
            DropTable("dbo.Categorias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ContatoJuridicoes", "Categoria_Id", c => c.Int());
            DropColumn("dbo.ContatoJuridicoes", "Categoria");
            CreateIndex("dbo.ContatoJuridicoes", "Categoria_Id");
            AddForeignKey("dbo.ContatoJuridicoes", "Categoria_Id", "dbo.Categorias", "Id");
        }
    }
}
