﻿using tickets_net_backend.Models;

namespace tickets_net_backend.Exceptions
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
            : base(FormattableString.CurrentCulture($"The {nameof(TicketCategory)} with id '{ticketCategoryId}' is not available for the {nameof(Event)} with id '{eventId}'.")) { }
    }
}
