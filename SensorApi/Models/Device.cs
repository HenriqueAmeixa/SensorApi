namespace SensorApi.Models
{
    public class Device
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<SensorReading> SensorReadings { get; set; } = new List<SensorReading>();
    }
}
