namespace API.DTOs
{
    public class EventFilterDto
    {
        public string? Category { get; set; }
        public int? AgeRangeStart { get; set; }
        public int? AgeRangeEnd { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? SortBy { get; set; }
        public string? SearchTerm { get; set; }
    }
}
