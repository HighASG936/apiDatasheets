namespace apiDatasheets.DTOs
{
    public class DatasheetDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Filename { get; set; }
    }
}
