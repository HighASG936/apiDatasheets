namespace apiDatasheets.DTOs
{
    public class DatasheetDtoInsert
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Filename { get; set; }
    }
}
