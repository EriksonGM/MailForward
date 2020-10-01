using System;

namespace MailForward.Services.Exceptions
{
    public class InvalidOriginException : Exception
    {
        public InvalidOriginException() : base("Invalid origin")
        {
            
        }
    }
}