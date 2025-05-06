using Microsoft.EntityFrameworkCore;
using SensorApi.Data;
using SensorApi.DTOs;
using SensorApi.Models;
using SensorApi.Services.Interfaces;

namespace SensorApi.Services
{
    public class DeviceService: IDeviceService
    {
        private readonly SensorDbContext _context;

        public DeviceService(SensorDbContext context)
        {
            _context = context;
        }

        public async Task<Device> CreateDeviceAsync(DeviceCreateDto dto)
        {
            var device = new Device
            {
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Device.Add(device);
            await _context.SaveChangesAsync();

            return device;
        }

        public async Task<List<DeviceDto>> GetAllDevicesAsync()
        {
            return await _context.Device
                .Select(d => new DeviceDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    CreatedAt = d.CreatedAt
                }).ToListAsync();
        }

        public async Task<Device?> GetByIdAsync(Guid id)
        {
            return await _context.Device.FindAsync(id);
        }
    }
}
