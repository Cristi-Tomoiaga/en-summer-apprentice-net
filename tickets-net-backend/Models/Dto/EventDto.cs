namespace tickets_net_backend.Models.Dto
{
    public class EventDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public VenueDto? Venue { get; set; }

        public string Image { get; set; } = string.Empty;

        public int AvailableSeats { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<TicketCategoryDto> TicketCategories { get; set; } = new List<TicketCategoryDto>();
    }
}
