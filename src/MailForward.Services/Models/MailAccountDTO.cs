using System;
using System.ComponentModel.DataAnnotations;
using MailForward.Data.Entities;

namespace MailForward.Services.Models
{
    public class MailAccountDTO
    {
        public MailAccountDTO()
        {
            
        }

        public MailAccountDTO(MailAccount ma)
        {
            IdMailAccount = ma.IdMailAccount;
            Description = ma.Description;
            Mail = ma.Mail;
            Server = ma.Server;
            UseSSL = ma.UseSSL;
            Port = ma.Port;
            User = ma.User;
            Password = ma.Password;
        }

        public Guid? IdMailAccount { get; set; }

        [MaxLength(50)]
        [Required]
        public string Description { get; set; }

        [MaxLength(50)]
        [Required]
        public string Server { get; set; }

        [MaxLength(50)]
        [Required]
        public string User { get; set; }

        [MaxLength(50)]
        [Required]
        public string Password { get; set; }

        [Required]
        [Range(1,65500)]
        public int Port { get; set; }

        [MaxLength(50)]
        [Required]
        public string Mail { get; set; }

        [Display(Name = "Use SSL")]
        public bool UseSSL { get; set; }
    }
}