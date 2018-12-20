using System;

namespace ST.SharedHelpersLib.Exceptions
{
    public class SupportTicketUserAlreadyExistsException : SupportTicketApplicationException
    {
        private static string _message = "User already exists.";

        public SupportTicketUserAlreadyExistsException() : base(_message)
        {
        }
        public SupportTicketUserAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SupportTicketUserAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
