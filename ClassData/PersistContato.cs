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

        public Contato ConsultarPorId(int id)
        {
            using (ContatoDbContext con = new ContatoDbContext())
            {
                var Consulta = con.Contatos.Include(e => e.Emails).Include(t => t.Telefones).First(x => x.Id == id);
                return Consulta;
            }
        }

        public List<Contato> ListarPorParamentro(string c)
        {
            using(ContatoDbContext context = new ContatoDbContext())
            {
                var Contatos = context.Contatos.Include(e => e.Emails).Include(t => t.Telefones).Include(j => j.ContatoJuridico).Where(n => n.Nome.Contains(c));
                List<Contato> listaContatos = Contatos.ToList<Contato>();

                return listaContatos;
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
            using (var context = new ContatoDbContext())
            {

                //Faz uma consulta no banco de dados e traz os dados relacionados a este registro
                var result = context.Contatos.Include(t => t.Telefones).Include(e => e.Emails).Single(c => c.Id == contato.Id);
                //Altera o valor do resultado trazido pelo banco de dados pelo que foi editado
                context.Entry(result).CurrentValues.SetValues(contato);
                //Deleta todos os registros de telefone com a chave estrangeira do registro
                foreach (var cont in result.Telefones.ToList())
                    if (!contato.Telefones.Any(s => s.Id == cont.Id))
                        context.Telefones.Remove(cont);
                //Deleta todos os registros de email com a chave estrangeira do registro
                foreach (var email in result.Emails.ToList())
                    if (!contato.Emails.Any(s => s.Id == email.Id))
                        context.Emails.Remove(email);
                //Altera registros de telefones existentes e acrescenta novos números, caso haja
                foreach (var newtel in contato.Telefones)
                {
                    var dbTel = result.Telefones.SingleOrDefault(s => s.Id == newtel.Id);
                    if (dbTel != null)
                        // Update subFoos that are in the newFoo.SubFoo collection
                        context.Entry(dbTel).CurrentValues.SetValues(newtel);
                    else
                        // Insert subFoos into the database that are not
                        // in the dbFoo.subFoo collection
                        result.Telefones.Add(newtel);
                }
                //Altera registros de emails existentes e acrescenta novos endeços, caso haja
                foreach (var newemail in contato.Emails)
                {
                    var dbEmail = result.Emails.SingleOrDefault(s => s.Id == newemail.Id);
                    if (dbEmail != null)
                        // Update subFoos that are in the newFoo.SubFoo collection
                        context.Entry(dbEmail).CurrentValues.SetValues(newemail);
                    else
                        // Insert subFoos into the database that are not
                        // in the dbFoo.subFoo collection
                        result.Emails.Add(newemail);
                }

                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var context = new ContatoDbContext())
            {
                //var contato = new Contato() { Id = id };

                var contato = context.Contatos.Find(id);
                var telefones = context.Telefones.Where(x => x.Contato.Id == id).ToList();
                var emails = context.Emails.Where(y => y.Contato.Id == id).ToList();

                if(telefones != null || telefones.Count != 0)
                {
                    foreach(Telefone t in telefones)
                    {
                        context.Telefones.Remove(t);
                    }
                }

                if (emails != null || emails.Count != 0)
                {
                    foreach (Email e in emails)
                    {
                        context.Emails.Remove(e);
                    }
                }

                context.Contatos.Remove(contato);

                context.SaveChanges();
            }
        }
    }
}
