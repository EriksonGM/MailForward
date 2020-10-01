using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailForward.Data.Entities
{
    public class Destiny
    {
        [Key]
        public Guid IdDestiny { get; set; }

        public Guid IdOrigin { get; set; }

        [ForeignKey("IdOrigin")]
        public Origin Origin { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
    }
}