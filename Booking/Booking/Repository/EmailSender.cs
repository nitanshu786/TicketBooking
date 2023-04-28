using Booking.Data;
using Booking.Model;
using Booking.Repository.IRepository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class EmailSender:IEmailSender
    {
        private const string TemplatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpconfig;
        private readonly ApplicationDbContext _context;
        public EmailSender(IOptions<SMTPConfigModel> smtpconfig,ApplicationDbContext context)
        {
            _smtpconfig = smtpconfig.Value;
            _context=context;
        }
        public  Task SendEmailAsync(string email, string subject)
        {
          
           
            Execute(email, subject).Wait();
            return Task.FromResult(0);
        }
        public async Task Execute(string email, string subject )
        {
            string setpassword = $"http://localhost:4200/password";
            try
            {
                string ToEmail =  email;
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_smtpconfig.UsernameEmail, "My email Name")

                };
                mail.To.Add(ToEmail);
                mail.CC.Add(_smtpconfig.CcEmail);
                mail.Subject = "Ticket Booking:" + subject;
                mail.IsBodyHtml = true;
                mail.Body = $"Click this link to set your password: {setpassword}";


                mail.Priority = MailPriority.High;
                using (SmtpClient smtp = new SmtpClient(_smtpconfig.PrimaryDomain, _smtpconfig.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_smtpconfig.UsernameEmail, _smtpconfig.UsernamePassward);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception cx)
            {

                string sr = cx.Message;
            }
        }


        private string GetEmailBody(string templatename)
        {
            var body = File.ReadAllText(string.Format(TemplatePath, templatename));
            return body;
        }
       
    }
}
