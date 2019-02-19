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
                }
                
                if(contatoJuridico.OrganizacaoSocial != null)
                {
                    int i = contatoJuridico.OrganizacaoSocial.Id;
                    contatoJuridico.OrganizacaoSocial = null;
                    contatoJuridico.OrganizacaoSocial = con.ContatoJuridicos.Find(i);
                }

                con.ContatoJuridicos.Add(contatoJuridico);
                con.SaveChanges();
            }
        }

        public ContatoJuridico ListarPorId(int id)
        {
            using (ContatoDbContext con = new ContatoDbContext())
            {
                var Consulta = con.ContatoJuridicos.Include(e => e.Emails).First(x => x.Id == id);
                return Consulta;
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

        public void Modificar(ContatoJuridico contato)
        {
            using (var context = new ContatoDbContext())
            {
                //Faz uma consulta no banco de dados e traz os dados relacionados a este registro
                var result = context.ContatoJuridicos.Include(t => t.Telefones).Include(e => e.Emails).Single(c => c.Id == contato.Id);
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
                        context.Entry(dbTel).CurrentValues.SetValues(newtel);
                    else
                        result.Telefones.Add(newtel);
                }
                //Altera registros de emails existentes e acrescenta novos endeços, caso haja
                foreach (var newemail in contato.Emails)
                {
                    var dbEmail = result.Emails.SingleOrDefault(s => s.Id == newemail.Id);
                    if (dbEmail != null)
                        context.Entry(dbEmail).CurrentValues.SetValues(newemail);
                    else
                        result.Emails.Add(newemail);
                }

                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using(var context = new ContatoDbContext())
            {
                var contato = new ContatoJuridico() { Id = id };
                context.ContatoJuridicos.Remove(contato);

                context.SaveChanges();
            }
        }
    }
}
