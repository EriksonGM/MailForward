using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MailForward.Data.Entities
{
    public class MailAccount
    {
        [Key]
        public Guid IdMailAccount { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Server { get; set; }

        [MaxLength(50)]
        public string User { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public int Port { get; set; }

        [MaxLength(50)]
        public string Mail { get; set; }

        public bool UseSSL { get; set; }

        public ICollection<Origin> Origins { get; set; }
    }
}
