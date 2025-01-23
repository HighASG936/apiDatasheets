namespace apiDatasheets.Models
{
    public class DataSheet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
    }
}
