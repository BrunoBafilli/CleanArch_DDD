using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Tools
{
    using Domain.DomainEvents.Order.Interfaces;
    using System;
    using System.Net;
    using System.Net.Mail;

    public class SendEmail : ISendEmail
    {
        private string smtpServer;
        private int smtpPort;
        private string senderEmail;
        private string password;

        public SendEmail()
        {
            this.smtpServer = "teste";
            this.smtpPort = 213;
            this.senderEmail = "teste";
            this.password = "teste";
        }

        public void Send(string toEmail, string subject, string body)
        {
            //MailMessage message = new MailMessage();
            //message.From = new MailAddress(senderEmail);
            //message.To.Add(new MailAddress(toEmail));
            //message.Subject = subject;
            //message.Body = body;

            //SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
            //smtp.Credentials = new NetworkCredential(senderEmail, password);
            //smtp.EnableSsl = true;

            //try
            //{
            //    smtp.Send(message);
            //    Console.WriteLine("Email enviado com sucesso!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Erro ao enviar email: " + ex.Message);
            //}
        }
    }

}
