namespace SensorApi.Models
{
    public class SensorReading
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DeviceId { get; set; }
        public float AccelX { get; set; }
        public float AccelY { get; set; }
        public float AccelZ { get; set; }
        public float? Temperature { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Device? Device { get; set; }
    }
}
