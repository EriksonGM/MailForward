using System;
using MailForward.Data;
using MailForward.Data.Entities;
using MailForward.Services.Exceptions;
using MailForward.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace MailForward.Services
{
    public interface IAllowedSiteService
    {
        public void Add(AllowedSiteDTO dto);

        public void Remove(Guid idAllowedSite);
    }
    public class AllowedSiteService : IAllowedSiteService
    {
        private readonly DataContext _db;

        public AllowedSiteService(DataContext db)
        {
            _db = db;
        }

        public void Add(AllowedSiteDTO dto)
        {
            var site = new AllowedSite
            {
                IdAllowedSite = Guid.NewGuid(),
                IdOrigin = dto.IdOrigin,
                Site = dto.Site
            };

            _db.AllowedSites.Add(site);

            _db.SaveChanges();
        }

        public void Remove(Guid idAllowedSite)
        {
            var site = _db.AllowedSites.Find(idAllowedSite);

            if(site == null)
                throw new InvalidAllowedSiteException();

            _db.Entry(site).State = EntityState.Deleted;

            _db.SaveChanges();
        }
    }
}