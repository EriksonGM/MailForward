using System;

namespace MailForward.Services.Exceptions
{
    public class InvalidAllowedSiteException : Exception
    {
        public InvalidAllowedSiteException() : base("Invalid Allowed Site")
        {
            
        }
    }
}