using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;

namespace ClassUtil
{
    public class ObterCaminhoAnexo
    {
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

    }
}
