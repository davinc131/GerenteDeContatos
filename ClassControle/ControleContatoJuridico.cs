
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;
using ClassData;
using ClassUtil;

namespace ClassControle
{
    public class ControleContatoJuridico
    {
        protected PersistContatoJuridico contato = new PersistContatoJuridico();

        public void salvarContatoJuridico(ContatoJuridico c)
        {
            contato.SalvarContatoJuridico(c);
        }

        public ContatoJuridico consultar(int id)
        {
            return contato.ConsultarPorId(id);
        }

        public List<ContatoJuridico> ListarContatoJuridico()
        {
            return contato.ListarContatos();
        }

        public List<ContatoJuridico> ListarPorParametro(string c)
        {
            return contato.ListarPorParamentro(c);
        }

        public void Excluir(int id)
        {
            contato.Excluir(id);
        }

        public void Modificar(ContatoJuridico c)
        {
            contato.Modificar(c);
        }

        public bool ValidarTelefone(string f)
        {
            return Validation.validarTelefone(f);
        }

        public bool validaEmail(string email)
        {
            return Validation.validarEmail(email);
        }

        public List<IsCheckedPessoaJuridica> ConverterEmIsChecked(List<ContatoJuridico> contatoJuridicos)
        {
            List<IsCheckedPessoaJuridica> listIsChecked = new List<IsCheckedPessoaJuridica>();

            foreach(ContatoJuridico cj in contatoJuridicos)
            {
                IsCheckedPessoaJuridica isCheckedPessoaJuridica = new IsCheckedPessoaJuridica();

                isCheckedPessoaJuridica.ContatoJuridico = cj;

                if(isCheckedPessoaJuridica.ContatoJuridico.Contatos.Count != 0)
                {
                    foreach(Contato cf in isCheckedPessoaJuridica.ContatoJuridico.Contatos)
                    {
                        IsCheckedPessoaFisica isCheckedPessoaFisica = new IsCheckedPessoaFisica();
                        isCheckedPessoaFisica.ContatoFisico = cf;
                        isCheckedPessoaJuridica.IsCheckedPessoas.Add(isCheckedPessoaFisica);
                    }
                }

                listIsChecked.Add(isCheckedPessoaJuridica);
            }

            return listIsChecked;
        }
    }
}
