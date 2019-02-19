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

        private string QuebrarString(string s)
        {
            string[] listString = s.Split('\\');
            string arquivo = listString[listString.Length - 1];

            return arquivo;
        }

        public Anexos RetornaAnexo(string x, Anexos a)
        {
            a.NomeDoArquivo = QuebrarString(x);
            a.Caminho = x;

            return a;
        }

        override
        public string ToString()
        {
            return NomeDoArquivo;
        }
    }
}
