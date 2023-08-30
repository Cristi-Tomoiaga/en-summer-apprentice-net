using TicketsNetBackend.Models;

namespace TicketsNetBackend.Exceptions
{
    public class OwnershipException : Exception
    {
        public OwnershipException()
        {
        }

        public OwnershipException(string? message) : base(message)
        {
        }

        public OwnershipException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public OwnershipException(int customerId, int orderId) 
            : base(FormattableString.Invariant($"The {nameof(Customer)} with id '{customerId}' is not the owner of the {nameof(Order)} with id '{orderId}'.")) { }
    }
}
