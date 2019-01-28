﻿using System;
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
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<ContatoJuridico> ContatoJuridicos { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
