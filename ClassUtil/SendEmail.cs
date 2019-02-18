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
                //// cria uma mensagem
                //MailMessage mensagemEmail = new MailMessage(Remetente, Destinatario, Assunto, enviaMensagem);

                //SmtpClient client = new SmtpClient("smtp.gmail.com", 465);//587
                //client.EnableSsl = true;
                //NetworkCredential cred = new NetworkCredential("davinc10831@gmail.com", "u@3r5v8k9cwporw");
                //client.Credentials = cred;

                //// inclui as credenciais
                //client.UseDefaultCredentials = true;

                //// envia a mensagem
                //client.Send(mensagemEmail);

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("davinc10831@gmail.com", "u@3r5v8k9cwporw");
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
                //// Cria uma mensagem
                //MailMessage mensagemEmail = new MailMessage(Remetente, Destinatario, Assunto, enviaMensagem);

                //// Obtem os anexos contidos em um arquivo arraylist e inclui na mensagem
                //foreach (string anexo in anexos)
                //{
                //    Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                //    mensagemEmail.Attachments.Add(anexado);
                //}

                //SmtpClient client = new SmtpClient("smtp.gmail.com", 465);//465
                //client.EnableSsl = true;
                //NetworkCredential cred = new NetworkCredential("davinc10831@gmail.com", "u@3r5v8k9cwporw");
                //client.Credentials = cred;

                //// Inclui as credenciais
                //client.UseDefaultCredentials = true;

                //// envia a mensagem
                //client.Send(mensagemEmail);

                //return "OK!";

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("davinc10831@gmail.com", "u@3r5v8k9cwporw");
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
