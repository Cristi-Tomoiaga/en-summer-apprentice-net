namespace TicketsNetBackend.Models.Dto
{
    public class TicketCategoryDto
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
