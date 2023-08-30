namespace tickets_net_backend.Exceptions
{
    public class InvalidNumberOfTicketsException : Exception
    {
        public InvalidNumberOfTicketsException()
        {
        }

        public InvalidNumberOfTicketsException(string? message) : base(message)
        {
        }

        public InvalidNumberOfTicketsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public InvalidNumberOfTicketsException(int numberOfTickets) 
            : base(FormattableString.CurrentCulture($"Invalid number of tickets '{numberOfTickets}' provided.")) { }
    }
}
