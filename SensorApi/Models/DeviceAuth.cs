namespace SensorApi.Models
{
    public class DeviceAuth
    {
        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public string ApiKey { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
