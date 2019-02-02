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
        public ICollection<Email> Emails { get; set; }
        public ICollection<Telefone> Telefones { get; set; }

        public Base()
        {
            Emails = new List<Email>();
            Telefones = new List<Telefone>();
        }

        override
        public string ToString()
        {
            return Nome;
        }
    }
}
