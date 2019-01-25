using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Base
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Tipo Tipo { get; set; }
        public List<Email> Emails { get; set; }
        public List<Telefone> Telefones { get; set; }

        override
        public string ToString()
        {
            return Nome;
        }
    }
}
