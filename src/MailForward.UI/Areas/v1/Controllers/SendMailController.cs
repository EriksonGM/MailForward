using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MailForward.Services;
using MailForward.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MailForward.UI.Areas.v1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IMailAccountService _mailAccount;
        private readonly ILogger<SendMailController> _logger;

        public SendMailController(ILogger<SendMailController> logger, IMailAccountService mailAccount)
        {
            _logger = logger;
            _mailAccount = mailAccount;
        }

        [HttpPost]
        public IActionResult Listener(SendMailViewModel model)
        {
            try
            {
                var files = Request.Form.Files;

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                //var origin = 

                var mail = new MailMessage();

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
