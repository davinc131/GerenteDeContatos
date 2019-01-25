using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;

namespace ClassData
{
    public class ContatoDbContext:DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<ContatoJuridico> ContatoJuridicos { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
    }
}
