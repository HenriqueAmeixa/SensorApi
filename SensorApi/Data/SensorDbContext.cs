using Microsoft.EntityFrameworkCore;
using SensorApi.Models;

namespace SensorApi.Data
{
    public class SensorDbContext: DbContext
    {
        public SensorDbContext(DbContextOptions<SensorDbContext> options) : base(options) { }

        public DbSet<Device> Device => Set<Device>();
        public DbSet<SensorReading> SensorReading => Set<SensorReading>();
    }
}
