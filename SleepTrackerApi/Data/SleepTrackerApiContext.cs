using Microsoft.EntityFrameworkCore;
using SleepTrackerApi.Models;

namespace SleepTrackerApi.Data
{
    public class SleepTrackerApiContext : DbContext
    {
        public SleepTrackerApiContext(DbContextOptions<SleepTrackerApiContext> options)
            : base(options)
        {
        }

        public DbSet<SleepRecord> SleepRecord { get; set; } = default!;
    }
}
