using System;
using System.Collections.Generic;
using System.Text;
using MailForward.Data;
using MailForward.Data.Entities;
using MailForward.Services.Exceptions;
using MailForward.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace MailForward.Services
{
    public interface IDestinyService
    {
        public void Add(DestinyDTO dto);

        public void Remove(Guid idDestiny);
    }
    public class DestinyService : IDestinyService
    {
        private readonly DataContext _db;
        public DestinyService(DataContext db)
        {
            _db = db;
        }

        public void Add(DestinyDTO dto)
        {
            var destiny = new Destiny
            {
                IdDestiny = Guid.NewGuid(),
                IdOrigin = dto.IdOrigin,
                 Email = dto.Email
            };

            _db.Destinies.Add(destiny);

            _db.SaveChanges();
        }

        public void Remove(Guid idDestiny)
        {
            var destiny = _db.Destinies.Find(idDestiny);

            if(destiny == null)
                throw new InvalidDestinyException();

            _db.Entry(destiny).State = EntityState.Deleted;

            _db.SaveChanges();
        }
    }
}
