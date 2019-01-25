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
        public virtual List<ContatoJuridico> Vinculado { get; set; }
        public virtual List<Contato> Contatos { get; set; }
    }
}
