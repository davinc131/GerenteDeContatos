using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;
using System.Data.Entity;

namespace ClassData
{
    public class PersistContatoJuridico
    {
        public void SalvarContatoJuridico(ContatoJuridico contatoJuridico)
        {
            using (ContatoDbContext con = new ContatoDbContext())
            {
                if (contatoJuridico.Auditoria != null)
                {
                    int i = contatoJuridico.Auditoria.Id;
                    contatoJuridico.Auditoria = null;
                    contatoJuridico.Auditoria = con.ContatoJuridicos.Find(i);
                    con.ContatoJuridicos.Add(contatoJuridico);
                    con.SaveChanges();
                }
                else
                {
                    con.ContatoJuridicos.Add(contatoJuridico);
                    con.SaveChanges();
                }
            }
        }

        public List<ContatoJuridico> ListarContatos()
        {
            using (var context = new ContatoDbContext())
            {
                var Contatos = context.ContatoJuridicos.Include(e => e.Emails).Include(t => t.Telefones).Include(c => c.Contatos).Include(j => j.Juridicos).ToList();

                List<ContatoJuridico> listaContatos = Contatos.ToList<ContatoJuridico>();

                return listaContatos;
            }
        }

        public void Modificar(ContatoJuridico contatoJuridico)
        {
            using (var db = new ContatoDbContext())
            {
                var result = db.ContatoJuridicos.SingleOrDefault(b => b.Id == contatoJuridico.Id);

                if (result != null)
                {
                    result = contatoJuridico;
                    db.SaveChanges();
                }
            }
        }

        public void Excluir(int id)
        {
            using(var context = new ContatoDbContext())
            {
                var contato = context.ContatoJuridicos.Include(e => e.Emails).First();
                contato = context.ContatoJuridicos.Include(t => t.Telefones).First();

                var emails = contato.Emails.ToList();
                var telefone = contato.Telefones.ToList();

                context.ContatoJuridicos.Remove(contato);

                context.SaveChanges();
            }
        }
    }
}
