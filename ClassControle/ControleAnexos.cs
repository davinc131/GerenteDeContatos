using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;

namespace ClassControle
{
    public class ControleAnexos
    {
        Anexos anexos = new Anexos();

        public Anexos anexo(string s)
        {
            return anexos.RetornaAnexo(s, anexos);
        }
    }
}
