using TicketsNetBackend.Models;

namespace TicketsNetBackend.Exceptions
{
    public class InvalidTicketCategoryException : Exception
    {
        public InvalidTicketCategoryException()
        {
        }

        public InvalidTicketCategoryException(string? message) : base(message)
        {
        }

        public InvalidTicketCategoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public InvalidTicketCategoryException(int ticketCategoryId, int eventId) 
            : base(FormattableString.Invariant($"The {nameof(TicketCategory)} with id '{ticketCategoryId}' is not available for the {nameof(Event)} with id '{eventId}'.")) { }
    }
}
