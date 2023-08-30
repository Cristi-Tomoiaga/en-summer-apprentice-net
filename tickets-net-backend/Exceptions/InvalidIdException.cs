namespace TicketsNetBackend.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException()
        {
        }

        public InvalidIdException(string? message) : base(message)
        {
        }

        public InvalidIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public InvalidIdException(int entityId, string entityName) 
            : base(FormattableString.CurrentCulture($"Invalid id '{entityId}' provided for entity '{entityName}'.")) { }
    }
}
