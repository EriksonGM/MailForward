using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailForward.Data.Entities
{
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistory { get; set; }

        public Guid IdOrigin { get; set; }

        [ForeignKey("IdOrigin")]
        public Origin Origin { get; set; }

        public DateTime Date { get; set; }

        //public string 
    }
}