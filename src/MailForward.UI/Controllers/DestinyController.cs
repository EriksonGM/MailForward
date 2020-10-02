using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailForward.Services;
using MailForward.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MailForward.UI.Controllers
{
    public class DestinyController : Controller
    {
        private readonly ILogger<DestinyController> _logger;
        private readonly IDestinyService _destiny;
        public DestinyController(ILogger<DestinyController> logger, IDestinyService destiny)
        {
            _destiny = destiny;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Add(DestinyDTO dto)
        {

            try
            {
                _destiny.Add(dto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }

            return RedirectToAction("Info","Origins", new {id = dto.IdOrigin});
        }

        [HttpPost]
        public IActionResult Remove(DestinyDTO dto)
        {
            try
            {
                _destiny.Remove(dto.IdDestiny);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }

            return RedirectToAction("Info", "Origins", new { id = dto.IdOrigin });
        }
    }
}
