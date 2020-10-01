using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailForward.UI.Models
{
    public class SendMailViewModel
    {
        public Guid MailKey { get; set; }
        public IDictionary<string, string> Properties { get; set; }
    }

}
