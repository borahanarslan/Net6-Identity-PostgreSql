using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace PostgreSql.Models
{
    public class AuthMessageSender : IEmailSender
    {

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Hosting { get; }
        public AuthMessageSender(IConfiguration configuration, IWebHostEnvironment hosting)
        {
            Configuration = configuration;
            Hosting = hosting;
        }


        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage message = new();
                var smtp = new SmtpClient();
                message.Sender = new MailAddress(Configuration["Email:SmtpUsername"], Configuration["Email:FromAddressTitle"]);
                message.From = new MailAddress(Configuration["Email:SmtpUsername"], Configuration["Email:FromAddressTitle"]);
                message.To.Add(new MailAddress(email));

                message.Subject = subject;
                message.IsBodyHtml = true;

                message.Body = htmlMessage;
                smtp.Port = int.Parse(Configuration["Email:SmtpPort"]);
                smtp.Host = Configuration["Email:SmtpServer"];
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Configuration["Email:SmtpUsername"], Configuration["Email:SmtpPassword"]);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Task.CompletedTask;
        }
    }
}
