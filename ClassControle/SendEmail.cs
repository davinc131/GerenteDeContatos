using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassModel;
using ClassUtil;
using System.Windows;
using System.Windows.Controls;

namespace ClassControle
{
    public class SendEmail
    {
        public string EnviaEmail(List<Email> emails, List<string> anexos, string assunto, string mensagem)
        {
            try
            {
                foreach (Email e in emails)
                {
                    if (anexos.Count.Equals(0))
                    {
                        ClassUtil.SendEmail.EnviaMensagemEmail(e.EndEmail, "tibrgaap@gmail.com", assunto, mensagem);
                    }
                    else
                    {
                        ClassUtil.SendEmail.EnviaMensagemComAnexos(e.EndEmail, "tibrgaap@gmail.com", assunto, mensagem, anexos);
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
