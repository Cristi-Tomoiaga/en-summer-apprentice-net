namespace tickets_net_backend.Models.Dto
{
    public class OrderGetDto
    {
        public int Id { get; set; }

        public EventDto? Event { get; set; }

        public DateTime Timestamp { get; set; }

        public TicketCategoryDto? TicketCategory { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
