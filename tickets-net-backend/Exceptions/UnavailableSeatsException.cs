﻿using System.Runtime.Serialization;
using tickets_net_backend.Models;

namespace tickets_net_backend.Exceptions
{
    public class UnavailableSeatsException : Exception
    {
        public UnavailableSeatsException()
        {
        }

        public UnavailableSeatsException(string? message) : base(message)
        {
        }

        public UnavailableSeatsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public UnavailableSeatsException(int numberOfTickets, int availableSeats, int eventId)
            : base(FormattableString.CurrentCulture($"Unavailable number of tickets for {nameof(Event)} with the id '{eventId}': requested '{numberOfTickets}' tickets, available '{availableSeats}' seats.")) { }
    }
}
