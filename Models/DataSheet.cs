using System.ComponentModel.DataAnnotations.Schema;

namespace apiDatasheets.Models
{
    public class Datasheet
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        public required string Name { get; set; }

        [Column(TypeName = "text")]
        public string? Description { get; set; }


        [Column(TypeName = "text")]
        public string? Filename { get; set; }
    }
}
