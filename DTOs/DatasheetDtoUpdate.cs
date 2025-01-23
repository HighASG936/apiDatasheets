namespace apiDatasheets.DTOs
{
    public class DatasheetDtoUpdate
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Filename { get; set; }
    }
}
