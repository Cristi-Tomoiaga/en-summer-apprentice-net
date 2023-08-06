namespace tickets_net_backend.Exceptions
{
    public class InvalidNumberOfTickets : Exception
    {
        public InvalidNumberOfTickets()
        {
        }

        public InvalidNumberOfTickets(string? message) : base(message)
        {
        }

        public InvalidNumberOfTickets(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public InvalidNumberOfTickets(int numberOfTickets) 
            : base(FormattableString.CurrentCulture($"Invalid number of tickets '{numberOfTickets}' provided.")) { }
    }
}
