using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailForward.Data.Entities
{
    public class Origin
    {
        [Key]
        public Guid IdOrigin { get; set; }

        public string Description { get; set; }

        public Guid IdMailAccount { get; set; }

        [ForeignKey("IdMailAccount")]
        public MailAccount MailAccount { get; set; }

        public ICollection<AllowedSite> AllowedSites { get; set; }

        public ICollection<Destiny> Destinies { get; set; }
    }
}