using System;

namespace MailForward.Services.Exceptions
{
    public class MailAccountInUseException :Exception
    {
        public MailAccountInUseException() :base("Mail account in use")
        {
            
        }
    }
}