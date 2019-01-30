using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;
using System.Data.Entity;

namespace ClassData
{
    public class PersistContato
    {
        public void SalvarContato(Contato contato)
        {
            using (ContatoDbContext con = new ContatoDbContext())
            {
                if (contato.ContatoJuridico != null)
                {
                    int i = contato.ContatoJuridico.Id;
                    contato.ContatoJuridico = null;
                    contato.ContatoJuridico = con.ContatoJuridicos.Find(i);

                    con.Contatos.Add(contato);
                    con.SaveChanges();
                }
                else
                {
                    con.Contatos.Add(contato);
                    con.SaveChanges();
                }
            }
        }

        public List<Contato> ListarContatos()
        {
            using (var context = new ContatoDbContext())
            {
                var Contatos = context.Contatos.Include(e => e.Emails).Include(t => t.Telefones).Include(j => j.ContatoJuridico).ToList();
                List<Contato> listaContatos = Contatos.ToList<Contato>();

                return listaContatos;
            }
        }

        public void Modificar(Contato contato)
        {
            using (var db = new ContatoDbContext())
            {
                var result = db.Contatos.SingleOrDefault(b => b.Id == contato.Id);

                if (result != null)
                {
                    result = contato;
                    db.SaveChanges();
                }
            }
        }

        public void Excluir(int id)
        {
            using (var context = new ContatoDbContext())
            {
                var contato = context.Contatos.Include(e => e.Emails).First();
                contato = context.Contatos.Include(t => t.Telefones).First();

                var emails = contato.Emails.ToList();
                var telefone = contato.Telefones.ToList();

                context.Contatos.Remove(contato);

                context.SaveChanges();
            }
        }
    }
}
