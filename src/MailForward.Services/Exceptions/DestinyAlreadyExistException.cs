using System;

namespace MailForward.Services.Exceptions
{
    public class DestinyAlreadyExistException : Exception
    {
        public DestinyAlreadyExistException() : base("Email de destino ja cadastrado")
        {
            
        }
    }
}