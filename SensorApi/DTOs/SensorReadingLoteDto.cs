namespace SensorApi.DTOs
{
    public class SensorReadingLoteDto
    {
        public Guid DeviceId { get; set; }
        public DateTime Timestamp { get; set; }
        public List<SensorReadingLoteAmostraDto> Leituras { get; set; }
    }
}
