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
    public class ControleContato
    {
        protected PersistContato contato = new PersistContato();
        protected ValidarTelefone validarTelefone = new ValidarTelefone();
        protected ValidarEmail validarEmail = new ValidarEmail();

        public bool ValidarTelefone(string f)
        {
            return validarTelefone.validarTelefone(f);
        }

        public bool validaEmail(string email)
        {
            return validarEmail.validarEmail(email);
        }

        public void salvarContato(Contato c)
        {
            
        }
    }
}
