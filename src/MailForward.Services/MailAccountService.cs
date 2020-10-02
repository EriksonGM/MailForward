using System;
using System.Collections.Generic;
using System.Linq;
using MailForward.Data;
using MailForward.Data.Entities;
using MailForward.Services.Exceptions;
using MailForward.Services.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MailForward.Services
{
    public interface IMailAccountService
    {
        public Guid Add(MailAccountDTO dto);
        public void Update(MailAccountDTO dto);
        public void Delete(Guid idMailAccount);
        public MailAccountDTO GetById(Guid idMailAccount);
        public List<MailAccountDTO> List();

        public List<SelectListItem> SelectList();
    }
    public class MailAccountService : IMailAccountService
    {
        private readonly DataContext _db;
        public MailAccountService(DataContext db)
        {
            _db = db;
        }

        public Guid Add(MailAccountDTO dto)
        {
            var mail = new MailAccount
            {
                IdMailAccount = Guid.NewGuid(),
                Description = dto.Description,
                Mail = dto.Mail,
                Server = dto.Server,
                Port = dto.Port,
                Password = dto.Password,
                User = dto.User,
                UseSSL = dto.UseSSL
            };

            _db.MailAccounts.Add(mail);

            _db.SaveChanges();

            return mail.IdMailAccount;
        }

        public void Update(MailAccountDTO dto)
        {
            var mail = _db.MailAccounts.Find(dto.IdMailAccount);

            if (mail == null)
                throw new InvalidMailAccountException();

            mail.Description = dto.Description;
            mail.Mail = dto.Mail;
            mail.Server = dto.Server;
            mail.Password = dto.Password;
            mail.User = dto.User;
            mail.UseSSL = dto.UseSSL;
            mail.Port = dto.Port;

            _db.Entry(mail).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(Guid idMailAccount)
        {
            var mail = _db.MailAccounts.Include(x=>x.Origins).FirstOrDefault(x=>x.IdMailAccount == idMailAccount);

            if(mail == null)
                throw new InvalidMailAccountException();

            if(mail.Origins.Any())
                throw new MailAccountInUseException();

            _db.Entry(mail).State = EntityState.Deleted;

            _db.SaveChanges();
        }

        public MailAccountDTO GetById(Guid idMailAccount)
        {
            var mail = _db.MailAccounts.Include(x => x.Origins).FirstOrDefault(x => x.IdMailAccount == idMailAccount);

            if (mail == null)
                throw new InvalidMailAccountException();

            var dto = new MailAccountDTO
            {
                IdMailAccount = mail.IdMailAccount,
                Description = mail.Description,
                Mail = mail.Mail,
                User = mail.User,
                Port = mail.Port,
                Password = mail.Password,
                Server = mail.Server,
                UseSSL = mail.UseSSL
            };

            return dto;
        }

        public List<MailAccountDTO> List()
        {
            return _db.MailAccounts.Select(x => new MailAccountDTO
            {
                IdMailAccount = x.IdMailAccount,
                Description = x.Description,
                Mail = x.Mail,
                Server = x.Server,
                Port = x.Port
            }).ToList();
        }

        public List<SelectListItem> SelectList()
        {
            return _db.MailAccounts.Select(x => new SelectListItem
            {
                Value = x.IdMailAccount.ToString(),
                Text = x.Description
            }).ToList();
        }
    }
}