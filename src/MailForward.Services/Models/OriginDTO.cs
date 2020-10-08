using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailForward.Services.Models
{
    public class OriginDTO
    {
        public Guid? IdOrigin { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        public string Body { get; set; }
        public string Signature { get; set; }

        [Display(Name = "Mail Account")]
        public Guid IdMailAccount { get; set; }

        public MailAccountDTO MailAccount { get; set; }

        public List<DestinyDTO> Destinies { get; set; }

        public List<SelectListItem> MailAccounts { get; set; }

        public List<AllowedSiteDTO> AllowedSites { get; set; }
    }
}