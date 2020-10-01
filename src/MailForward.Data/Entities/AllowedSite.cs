using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailForward.Data.Entities
{
    public class AllowedSite
    {
        [Key]
        public Guid IdAllowedSite { get; set; }

        public Guid IdOrigin { get; set; }

        [ForeignKey("IdOrigin")]
        public Origin Origin { get; set; }

        public string Site { get; set; }
    }
}