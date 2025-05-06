using Microsoft.EntityFrameworkCore;
using SensorApi.Data;
using SensorApi.DTOs;
using SensorApi.Models;
using SensorApi.Services.Interfaces;

namespace SensorApi.Services
{
    public class SensorReadingService : ISensorReadingService
    {
        private readonly SensorDbContext _context;

        public SensorReadingService(SensorDbContext context)
        {
            _context = context;
        }

        public async Task<SensorReadingDto> CreateAsync(SensorReadingCreateDto dto)
        {
            var reading = new SensorReading
            {
                DeviceId = dto.DeviceId,
                AccelX = dto.AccelX,
                AccelY = dto.AccelY,
                AccelZ = dto.AccelZ,
                Temperature = dto.Temperature,
                Timestamp = dto.Timestamp
            };

            _context.SensorReading.Add(reading);
            await _context.SaveChangesAsync();

            return new SensorReadingDto
            {
                Id = reading.Id,
                DeviceId = reading.DeviceId,
                AccelX = reading.AccelX,
                AccelY = reading.AccelY,
                AccelZ = reading.AccelZ,
                Temperature = reading.Temperature,
                Timestamp = reading.Timestamp
            };
        }

        public async Task<List<SensorReadingDto>> GetByDeviceIdAsync(Guid deviceId)
        {
            return await _context.SensorReading
                .Where(r => r.DeviceId == deviceId)
                .Select(r => new SensorReadingDto
                {
                    Id = r.Id,
                    DeviceId = r.DeviceId,
                    AccelX = r.AccelX,
                    AccelY = r.AccelY,
                    AccelZ = r.AccelZ,
                    Temperature = r.Temperature,
                    Timestamp = r.Timestamp
                }).ToListAsync();
        }
    }
}
