namespace TicketsNetBackend.Models.Dto
{
    public class OrderPatchDto
    {
        public int TicketCategoryId { get; set; }
        
        public int NumberOfTickets { get; set; }
    }
}
