using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MailForward.Services;
using MailForward.UI.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace MailForward.UI.Areas.v1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IMailAccountService _mailAccount;
        private readonly ILogger<SendMailController> _logger;
        private readonly IOriginService _origin;
        private readonly IAllowedSiteService _allowedSite;
        public SendMailController(
            ILogger<SendMailController> logger
            , IMailAccountService mailAccount
            , IAllowedSiteService allowedSite
            , IOriginService origin)
        {
            _logger = logger;
            _mailAccount = mailAccount;
            _allowedSite = allowedSite;
            _origin = origin;
        }

        [HttpPost]
        public IActionResult Listener(SendMailViewModel model)
        {
            try
            {
                /*
                var files = Request.Form.Files;

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                */
                var origin = _origin.GetById(model.MailKey);

                var mail = new MimeMessage();

                mail.From.Add(new MailboxAddress(origin.MailAccount.Mail));

                foreach (var d in origin.Destinies)
                {
                    mail.To.Add(new MailboxAddress(d.Email));
                }

                var body = $"{origin.Body}\n\n";

                foreach (var p in model.Properties)
                {
                    body += $"{p.Key}: {p.Value} \n\n";
                }

                //mail.Body += $"<hr>";

                if (!string.IsNullOrEmpty(origin.Signature))
                    body += $"\n\n{origin.Signature}";

                mail.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = body };

                mail.Subject = origin.Subject;

                using (var client = new SmtpClient())
                {
                    try
                    {
                        if (origin.MailAccount.UseSSL)
                        {
                            client.Connect(origin.MailAccount.Server, origin.MailAccount.Port, origin.MailAccount.UseSSL);
                            client.Authenticate(origin.MailAccount.User, origin.MailAccount.Password);
                        }
                            
                        else
                            client.Connect(origin.MailAccount.Server, origin.MailAccount.Port, SecureSocketOptions.None);


                        client.AuthenticationMechanisms.Remove("XOAUTH2");

                        client.Send(mail);
                    }
                    catch
                    {
                        //log an error message or throw an exception or both.
                        throw;
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
                }


                //var mailService = new SmtpClient(origin.MailAccount.Server, origin.MailAccount.Port);



                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    }
}
