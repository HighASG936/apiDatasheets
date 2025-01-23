using Microsoft.EntityFrameworkCore;

namespace apiDatasheets.Models
{
    public class DataSheetsContext : DbContext
    {
        public DataSheetsContext(DbContextOptions<DataSheetsContext> options) : base(options) { }
        public DbSet<DataSheet> DataSheets { get; set; }
    }
}
