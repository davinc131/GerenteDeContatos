using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Contato:Base
    {
        public virtual ContatoJuridico ContatoJuridico { get; set; }
        public Departamento Departamento { get; set; }

        public string ToDetalhes()
        {
            return Nome + " - " + Departamento;
        }
    }
}
