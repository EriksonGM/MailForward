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
    public class MailAccountsController : Controller
    {
        private readonly ILogger<MailAccountsController> _logger;
        private readonly IMailAccountService _mailAccount;
        public MailAccountsController(ILogger<MailAccountsController> logger, IMailAccountService mailAccount)
        {
            _logger = logger;
            _mailAccount = mailAccount;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info(Guid id)
        {
            var dto = _mailAccount.GetById(id);
            return View(dto);
        }

        public IActionResult Edit(Guid? id)
        {
            var res = id.HasValue ? _mailAccount.GetById(id.Value) : new MailAccountDTO();
                
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(MailAccountDTO dto)
        {
            if (dto.IdMailAccount.HasValue)
            {
                _mailAccount.Update(dto);
                return RedirectToAction("Index");
            }
            else
            {
                var res =_mailAccount.Add(dto);
                return RedirectToAction("Info", new {id = res});
            }
        }

        public IActionResult Delete(Guid id)
        {
            return View();
        }
    }
}
