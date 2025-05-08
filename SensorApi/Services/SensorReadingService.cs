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

        public async Task<List<SensorReadingDto>> GetByDeviceIdAsync(Guid deviceId, DateTime? after = null, int? limit = 100)
        {
            var query = _context.SensorReading
                .Where(r => r.DeviceId == deviceId);

            if (after.HasValue)
                query = query.Where(r => r.Timestamp > after.Value);

            query = query.OrderBy(r => r.Timestamp);

            if (limit.HasValue)
                query = query.Take(limit.Value);

            return await query
                .Select(r => new SensorReadingDto
                {
                    Id = r.Id,
                    DeviceId = r.DeviceId,
                    AccelX = r.AccelX,
                    AccelY = r.AccelY,
                    AccelZ = r.AccelZ,
                    Temperature = r.Temperature,
                    Timestamp = r.Timestamp
                })
                .ToListAsync();
        }


        public async Task CreateManyAsync(IEnumerable<SensorReading> leituras)
        {
            if (leituras == null || !leituras.Any())
                return;

            await _context.SensorReading.AddRangeAsync(leituras);
            await _context.SaveChangesAsync();
        }
    }
}
