namespace TicketsNetBackend.Models.Dto
{
    public class VenueDto
    {
        public int Id { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int Capacity { get; set; }
    }
}
