using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;

namespace ClassData
{
    public class PersistContatoJuridico
    {
        public void SalvarContatoJuridico(ContatoJuridico contatoJuridico)
        {
            using (ContatoDbContext con = new ContatoDbContext())
            {
                con.ContatoJuridicos.Add(contatoJuridico);
                con.SaveChanges();
            }
        }
    }
}
