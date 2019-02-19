using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassUtil;
using ClassModel;

namespace ClassControle
{
    public class ControleAnexos
    {
        Anexos anexos = new Anexos();
        ObterCaminhoAnexo caminho = new ObterCaminhoAnexo();

        public Anexos anexo(string s)
        {
            return caminho.RetornaAnexo(s, anexos);
        }
    }
}
