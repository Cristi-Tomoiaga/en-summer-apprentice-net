namespace tickets_net_backend.Models.Dto
{
    public class OrderGetDto
    {
        public int EventId { get; set; }

        public DateTime Timestamp { get; set; }

        public int TicketCategoryId { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
