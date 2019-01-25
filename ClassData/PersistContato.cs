using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;

namespace ClassData
{
    public class PersistContato
    {
        public static void SalvarEmpresa(Contato contato)
        {
            using (ContatoDbContext con = new ContatoDbContext())
            {
                con.Contatos.Add(contato);
                con.SaveChanges();
            }
        }
    }
}
