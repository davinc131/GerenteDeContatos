using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Telefone
    {
        public int Id { get; set; }
        public string NumTelefone { get; set; }
        public Departamento Departamento { get; set; }
        public bool Celular { get; set; }
        public bool Whatsapp { get; set; }

        public virtual Contato Contato { get; set; }
        public virtual ContatoJuridico ContatoJuridico { get; set; }

        override
        public string ToString()
        {
            return NumTelefone;
        }
    }
}
