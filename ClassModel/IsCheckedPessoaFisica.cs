using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class IsCheckedPessoaFisica
    {
        public Contato ContatoFisico { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return ContatoFisico.Nome;
        }
    }
}
