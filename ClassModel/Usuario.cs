using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string senha { get; set; }
        public bool superUsuario { get; set; }
        public UsuarioTipo Tipo { get; set; }
    }
}
