using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailForward.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailForward.UI.Areas.v1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SendMail : ControllerBase
    {
        [HttpPost]
        public IActionResult Listener(SendMailViewModel model)
        {

            return Ok();
        }
    }
}
