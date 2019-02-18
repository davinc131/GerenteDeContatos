using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Anexos
    {
        public string Caminho { get; set; }
        public string NomeDoArquivo { get; set; }

        override
        public string ToString()
        {
            return NomeDoArquivo;
        }
    }
}
