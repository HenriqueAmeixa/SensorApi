namespace SensorApi.Models
{
    public class SensorReading
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DeviceId { get; set; }
        public double AccelX { get; set; }
        public double AccelY { get; set; }
        public double AccelZ { get; set; }
        public double? Temperature { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Device? Device { get; set; }
    }
}
