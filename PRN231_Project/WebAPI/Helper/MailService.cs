using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebAPI.Helper
{
    public class MailService
    {
        private static MailService _instance = null;
        private static object locker = new object();
        private string ApiKey { get; set; }
        private string FromEmail { get; set; }
        private MailService()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            ApiKey = configuration.GetSection("EmailService").GetSection("ApiKey").Value;
            FromEmail = configuration.GetSection("EmailService").GetSection("FromEmail").Value;
        }
        public static MailService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        _instance = new MailService();
                    }
                }
                return _instance;
            }
        }
        public async Task SendEmail(string to, string body, string subject)
        {
            Task task = new Task(SendEmailAction, new { to = to, subject = subject, body=body });
            task.Start();
            await task;
        }
        private void SendEmailAction(object param)
        {
            try
            {
                dynamic obj = param;
                // configure client
                var config = new Configuration();
                config.ApiKey.Add("x-api-key", ApiKey);
                var inboxController = new InboxControllerApi(config);

                // create an smtp inbox
                var imapSmtpAccessDetails = inboxController.GetImapSmtpAccess();
                var smtpClient = new SmtpClient(imapSmtpAccessDetails.SmtpServerHost)
                {
                    Port = imapSmtpAccessDetails.SmtpServerPort,
                    Credentials = new NetworkCredential(userName: imapSmtpAccessDetails.SmtpUsername, password: imapSmtpAccessDetails.SmtpPassword),
                    // disable ssl recommended
                    EnableSsl = false
                };
                smtpClient.Send(from: FromEmail, recipients: obj.to, subject: obj.subject, body: obj.body);
                Console.WriteLine("Successfully Sent Email");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
