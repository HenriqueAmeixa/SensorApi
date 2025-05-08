using SensorApi.DTOs;
using SensorApi.Models;

namespace SensorApi.Services.Interfaces
{
    public interface ISensorReadingService
    {
        Task<SensorReadingDto> CreateAsync(SensorReadingCreateDto dto);
        Task<List<SensorReadingDto>> GetByDeviceIdAsync(Guid deviceId, int? afterId = null, int? limit = 100);
        Task CreateManyAsync(IEnumerable<SensorReading> readings);
    }
}
