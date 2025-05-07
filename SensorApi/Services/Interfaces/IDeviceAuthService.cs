using SensorApi.Models;

namespace SensorApi.Services.Interfaces
{
    public interface IDeviceAuthService
    {
        Task<DeviceAuth?> GetDeviceByApiKeyAsync(string apiKey);
    }
}
