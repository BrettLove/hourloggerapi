using Microsoft.EntityFrameworkCore;

namespace HourLoggerApi.Models
{
    public class HourLoggerContext : DbContext
    {

        // constructor
        public HourLoggerContext(DbContextOptions options)
            : base(options)
            {
            }

        // table<row>
        public DbSet<Day> DayLog { get; set; }

    }
}