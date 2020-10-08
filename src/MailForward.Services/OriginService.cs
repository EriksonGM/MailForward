using System;
using System.Collections.Generic;
using System.Linq;
using MailForward.Data;
using MailForward.Data.Entities;
using MailForward.Services.Exceptions;
using MailForward.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace MailForward.Services
{
    public interface IOriginService
    {
        public Guid Add(OriginDTO dto);

        public void Update(OriginDTO dto);

        public List<OriginDTO> List();

        public void Delete(Guid idOrigin);

        public OriginDTO GetById(Guid idOrigin);

        //public 
    }

    public class OriginService : IOriginService
    {
        private readonly DataContext _db;
        public OriginService(DataContext db)
        {
            _db = db;
        }
        public Guid Add(OriginDTO dto)
        {
            var origin = new Origin
            {
                IdOrigin = Guid.NewGuid(),
                Subject = dto.Subject,
                Body = dto.Body,
                Description = dto.Description,
                IdMailAccount = dto.IdMailAccount
            };

            _db.Origins.Add(origin);

            _db.SaveChanges();

            return origin.IdOrigin;
        }

        public void Update(OriginDTO dto)
        {
            var origin = _db.Origins.Find(dto.IdOrigin);

            if(origin == null)
                throw new InvalidOriginException();

            origin.Description = dto.Description;
            origin.Subject = dto.Subject;
            origin.Body = dto.Body;
            origin.Signature = dto.Signature;
            origin.IdMailAccount = dto.IdMailAccount;

            _db.Entry(origin).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public List<OriginDTO> List()
        {
            return _db.Origins.Select(x => new OriginDTO
            {
                IdOrigin = x.IdOrigin,
                Subject = x.Subject,
                Body = x.Body,
                Description = x.Description,
                Signature = x.Signature,
                IdMailAccount = x.IdMailAccount,
                MailAccount = new MailAccountDTO(x.MailAccount)
            }).ToList();
        }

        public void Delete(Guid idOrigin)
        {
            var origin = _db.Origins.Find(idOrigin);

            if (origin == null)
                throw new InvalidOriginException();

            _db.Entry(origin).State = EntityState.Deleted;

            _db.SaveChanges();
        }

        public OriginDTO GetById(Guid idOrigin)
        {
            var origin = _db.Origins
                .Include(x => x.MailAccount)
                .Include(x => x.AllowedSites)
                .Include(x => x.Destinies)
                .FirstOrDefault(x => x.IdOrigin == idOrigin);

            if(origin == null)
                throw new InvalidOriginException();

            var res = new OriginDTO
            {
                IdOrigin = origin.IdOrigin,
                Subject = origin.Subject,
                Body = origin.Body,
                Description = origin.Description,
                IdMailAccount = origin.IdMailAccount,
                MailAccount = new MailAccountDTO(origin.MailAccount),
                Destinies = origin.Destinies.Select(x=> new DestinyDTO(x)).ToList(),
                AllowedSites = origin.AllowedSites.Select(x=> new AllowedSiteDTO(x)).ToList()
            };

            return res;
        }


    }
}
