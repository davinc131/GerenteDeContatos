using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Configuration;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Collections;

namespace ClassUtil
{
    /// <summary>
    /// Classe responsável por envio de email
    /// </summary>
    public class SendEmail
    {
        public static string EnviaMensagemEmail(string Destinatario, string Remetente, string Assunto, string enviaMensagem)
        {
            try
            {
                
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(Remetente, "u@3r5v8k9cwporw");
                MailMessage mail = new MailMessage();
                mail.Sender = new System.Net.Mail.MailAddress(Remetente, "BRGAAP");
                mail.From = new MailAddress(Remetente, "BRGAAP");
                mail.To.Add(new MailAddress(Destinatario, "PARCEIRO BRGAAP"));
                mail.Subject = Assunto;
                mail.Body = enviaMensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;


                client.Send(mail);
                return "Success!";
            }
            catch (Exception ex)
            {
                string erro = ex.InnerException.ToString();
                return erro + " Error -  " + ex.Message;
            }
        }

        public static string EnviaMensagemComAnexos(string Destinatario, string Remetente, string Assunto, string enviaMensagem, List<string> anexos)
        {
            try
            {
                
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(Remetente, "u@3r5v8k9cwporw");
                MailMessage mail = new MailMessage();
                mail.Sender = new System.Net.Mail.MailAddress(Remetente, "BRGAAP");
                mail.From = new MailAddress(Remetente, "BRGAAP");
                mail.To.Add(new MailAddress(Destinatario, "PARCEIRO BRGAAP"));
                mail.Subject = Assunto;
                mail.Body = enviaMensagem;

                // Obtem os anexos contidos em um arquivo arraylist e inclui na mensagem
                foreach (string anexo in anexos)
                {
                    Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                    mail.Attachments.Add(anexado);
                }

                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                client.Send(mail);

                return "Success!";
            }
            catch (Exception ex)
            {
                string erro = ex.InnerException.ToString();
                return erro + " Error -  " + ex.Message;
            }
        }
    }
}
