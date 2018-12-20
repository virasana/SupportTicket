using System;

namespace ST.SharedHelpersLib.Exceptions
{
    public class SupportTicketDatabaseException : SupportTicketApplicationException
    {
        private static string _message = "Could not perform operation on the database";
        public SupportTicketDatabaseException(): base(_message)
        {
        }

        public SupportTicketDatabaseException(Exception innerException): base(_message, innerException)
        {
        }

        public SupportTicketDatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SupportTicketDatabaseException(string message)
            : base(message)
        {
        }
    }
}
