using System;

namespace MailForward.Services.Exceptions
{
    public class InvalidDestinyException : Exception
    {
        public InvalidDestinyException() : base("Invalid email destiny")
        {
            
        }
    }
}