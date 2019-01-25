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
        public bool Celular { get; set; }
        public bool Whatsapp { get; set; }

        override
        public string ToString()
        {
            return NumTelefone;
        }
    }
}
