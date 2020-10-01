using System;

namespace MailForward.Services.Exceptions
{
    public class InvalidMailAccountException : Exception
    {
        public InvalidMailAccountException() : base("Invalid mail account")
        {
            
        }
    }
}