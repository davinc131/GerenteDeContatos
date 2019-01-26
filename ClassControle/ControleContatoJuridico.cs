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
        protected ValidarTelefone validarTelefone = new ValidarTelefone();
        protected ValidarEmail validarEmail = new ValidarEmail();

        public void salvarContatoJuridico(ContatoJuridico c)
        {

        }

        public bool ValidarTelefone(string f)
        {
            return validarTelefone.validarTelefone(f);
        }

        public bool validaEmail(string email)
        {
            return validarEmail.validarEmail(email);
        }
    }
}
