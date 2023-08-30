namespace TicketsNetBackend.Exceptions
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
            : base(FormattableString.Invariant($"Invalid number of tickets '{numberOfTickets}' provided.")) { }
    }
}
