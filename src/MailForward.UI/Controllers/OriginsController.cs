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
    public class OriginsController : Controller
    {
        private readonly ILogger<OriginsController> _logger;
        private readonly IOriginService _origin;
        private readonly IMailAccountService _mailAccount;
        public OriginsController(
            ILogger<OriginsController> logger, 
            IOriginService origin, 
            IMailAccountService mailAccount)
        {
            _logger = logger;
            _origin = origin;
            _mailAccount = mailAccount;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info(Guid id)
        {
            var res = _origin.GetById(id);
            return View(res);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id.HasValue)
            {
                var res = _origin.GetById(id.Value);

                res.MailAccounts = _mailAccount.SelectList();

                return View(res);
            }
            else
            {
                var res = new OriginDTO
                {
                    MailAccounts = _mailAccount.SelectList()
                };

                return View(res);
            }
            
        }

        [HttpPost]
        public IActionResult Edit(OriginDTO dto)
        {
            try
            {
                if (dto.IdOrigin.HasValue)
                {
                    _origin.Update(dto);

                    return RedirectToAction("Index");
                }
                else
                {
                    var res = _origin.Add(dto);

                    return RedirectToAction("Info", new {id = res});
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;

                return View(dto);
            }
        }

    }
}
