using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class ContatoJuridico:Base
    {
        public Categoria Categoria { get; set; }
        public virtual ContatoJuridico ContatoJur { get; set; }
        public List<Contato> Contatos { get; set; }
        public List<ContatoJuridico> Juridicos { get; set; }
    }
}
