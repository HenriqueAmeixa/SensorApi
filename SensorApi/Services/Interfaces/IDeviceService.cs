using SensorApi.DTOs;
using SensorApi.Models;

namespace SensorApi.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<Device> CreateDeviceAsync(DeviceCreateDto dto);
        Task<List<DeviceDto>> GetAllDevicesAsync();
        Task<Device?> GetByIdAsync(Guid id);
    }
}
