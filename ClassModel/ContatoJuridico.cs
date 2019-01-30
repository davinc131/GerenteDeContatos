using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    /// <summary>
    /// Nos casos em que a categoria do objeto for Auditoria ou Organização_Social os atributos
    /// Auditoria e OrganizacaoSocial são nulos
    /// </summary>
    public class ContatoJuridico:Base
    {
        public Categoria Categoria { get; set; }
        public virtual ContatoJuridico Auditoria { get; set; }
        public virtual ContatoJuridico OrganizacaoSocial { get; set; }
        public List<Contato> Contatos { get; set; }
        public List<ContatoJuridico> Juridicos { get; set; }
    }
}
