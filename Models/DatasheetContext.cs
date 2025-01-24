using Microsoft.EntityFrameworkCore;

namespace apiDatasheets.Models
{
    public class DatasheetContext(DbContextOptions<DatasheetContext> options) : DbContext(options)
    {
        public DbSet<Datasheet> Datasheets { get; set; }
    }
}
