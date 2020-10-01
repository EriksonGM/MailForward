using System;
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

        public Guid IdMailAccount { get; set; }

        public MailAccountDTO MailAccount { get; set; }
    }
}