using System;
using System.ComponentModel.DataAnnotations;
using MailForward.Data.Entities;

namespace MailForward.Services.Models
{
    
    public class DestinyDTO
    {
        public DestinyDTO()
        {
            
        }

        public DestinyDTO(Destiny d)
        {
            IdDestiny = d.IdDestiny;
            IdOrigin = d.IdOrigin;
            Email = d.Email;
        }

        public Guid IdDestiny { get; set; }

        public Guid IdOrigin { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}