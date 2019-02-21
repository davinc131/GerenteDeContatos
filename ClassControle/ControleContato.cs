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

        public bool ValidarTelefone(string f)
        {
            return Validation.validarTelefone(f);
        }

        public bool validaEmail(string email)
        {
            return Validation.validarEmail(email);
        }

        public void salvarContato(Contato c)
        {
            contato.SalvarContato(c);
        }

        public Contato consultar(int id)
        {
            return contato.ConsultarPorId(id);
        }

        public List<Contato> ListarContatos()
        {
            return contato.ListarContatos();
        }

        public List<Contato> ListarPorParametro(string c)
        {
            return contato.ListarPorParamentro(c);
        }

        public void Modificar(Contato c)
        {
            contato.Modificar(c);
        }

        public void Excluir(int id)
        {
            contato.Excluir(id);
        }
    }
}
