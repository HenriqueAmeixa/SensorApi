namespace SensorApi.DTOs
{
    public class SensorReadingDto
    {
        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public double AccelX { get; set; }
        public double AccelY { get; set; }
        public double AccelZ { get; set; }
        public double? Temperature { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
