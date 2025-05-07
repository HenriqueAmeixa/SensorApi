namespace SensorApi.DTOs
{
    public class SensorReadingDto
    {
        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public float AccelX { get; set; }
        public float AccelY { get; set; }
        public float AccelZ { get; set; }
        public float? Temperature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
