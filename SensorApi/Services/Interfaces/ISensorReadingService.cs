using SensorApi.DTOs;

namespace SensorApi.Services.Interfaces
{
    public interface ISensorReadingService
    {
        Task<SensorReadingDto> CreateAsync(SensorReadingCreateDto dto);
        Task<List<SensorReadingDto>> GetByDeviceIdAsync(Guid deviceId);
    }
}
