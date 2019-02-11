
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

        public List<ContatoJuridico> ListarContatoJuridico()
        {
            return contato.ListarContatos();
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
    }
}
