using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;
using ClassUtil;
using System.Windows;
using System.Windows.Controls;
using ClassUtil;

namespace ClassControle
{
    public class SendEmail
    {
        public void EnviaEmail(List<Email> emails)
        {
            foreach(Email e in emails)
            {
                ClassUtil.SendEmail.EnviaMensagemEmail(e.EndEmail, "davinc10831@gmail.com", "Teste Envio Email", "Teste simples de envio de email");
            }
        }
    }
}
