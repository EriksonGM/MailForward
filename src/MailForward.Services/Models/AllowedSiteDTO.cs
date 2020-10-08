using System;
using System.ComponentModel.DataAnnotations;
using MailForward.Data.Entities;

namespace MailForward.Services.Models
{
    public class AllowedSiteDTO
    {
        public AllowedSiteDTO()
        {
            
        }
        public AllowedSiteDTO(AllowedSite allowed)
        {
            IdAllowedSite = allowed.IdAllowedSite;
            IdOrigin = allowed.IdOrigin;
            Site = allowed.Site;

        }

        public Guid IdAllowedSite { get; set; }

        [Required]
        public Guid IdOrigin { get; set; }

        public OriginDTO Origin { get; set; }

        [Url]
        public string Site { get; set; }
    }
}