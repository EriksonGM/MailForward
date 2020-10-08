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
    public class AllowedSiteController : Controller
    {
        private readonly IAllowedSiteService _allowedSite;
        private readonly ILogger<AllowedSiteController> _logger;

        public AllowedSiteController(ILogger<AllowedSiteController> logger, IAllowedSiteService allowedSite)
        {
            _logger = logger;
            _allowedSite = allowedSite;
        }

        [HttpPost]
        public IActionResult Add(AllowedSiteDTO dto)
        {
            try
            {
                _allowedSite.Add(dto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Info", "Origins", new { id = dto.IdOrigin });
        }

        [HttpPost]
        public IActionResult Remove(AllowedSiteDTO dto)
        {
            try
            {
                _allowedSite.Remove(dto.IdAllowedSite);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Info", "Origins", new { id = dto.IdOrigin });
        }
    }
}
