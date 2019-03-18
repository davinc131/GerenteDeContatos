using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClassModel;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClassData
{
    public class ContatoDbContext:DbContext
    {
        public ContatoDbContext() : base(@"data source=localhost\sqlexpress; Initial Catalog=ContatoDb; User Id=sa; Password=sipef@adm; integrated security=true;")
        {

        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<ContatoJuridico> ContatoJuridicos { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Atendimento> Atendimentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
