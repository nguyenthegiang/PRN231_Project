using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebAPI.Helper
{
    public class MailService
    {
        public static async Task SendEmail(string to, string body, string subject)
        {
            Task task = new Task(SendEmailAction, new { to = to, subject = subject, body=body });
            task.Start();
            await task;
        }
        private static void SendEmailAction(object param)
        {
            try
            {
                dynamic obj = param;
                var apiKey = "7561da6a4c9c77ca1efe4dbe45894cccd790658da1f31346b5ecb3837cf34249";

                // configure client
                var config = new Configuration();
                config.ApiKey.Add("x-api-key", apiKey);
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
                smtpClient.Send(from: "test@external.com", recipients: obj.to, subject: obj.subject, body: obj.body);
                Console.WriteLine("Successfully Sent Email");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
