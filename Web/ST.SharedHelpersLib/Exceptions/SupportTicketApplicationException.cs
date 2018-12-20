using System;
using System.Runtime.Serialization;

namespace ST.SharedHelpersLib.Exceptions
{
    public class SupportTicketApplicationException : Exception
    {
        public SupportTicketApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SupportTicketApplicationException(string message)
            : base(message)
        {
        }
    }
}
