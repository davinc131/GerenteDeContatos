using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class IsCheckedPessoaJuridica
    {
        public ContatoJuridico ContatoJuridico { get; set; }
        public List<IsCheckedPessoaFisica> IsCheckedPessoas { get; set; }
        public bool IsChecked { get; set; }

        public IsCheckedPessoaJuridica()
        {
            IsCheckedPessoas = new List<IsCheckedPessoaFisica>();
        }

        public override string ToString()
        {
            return ContatoJuridico.Nome;
        }
    }
}
