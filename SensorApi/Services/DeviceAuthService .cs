using Microsoft.EntityFrameworkCore;
using SensorApi.Data;
using SensorApi.Models;
using SensorApi.Services.Interfaces;

namespace SensorApi.Services
{
    public class DeviceAuthService: IDeviceAuthService
    {
        private readonly SensorDbContext _context;

        public DeviceAuthService(SensorDbContext context)
        {
            _context = context;
        }

        public async Task<DeviceAuth?> GetDeviceByApiKeyAsync(string apiKey)
        {
            return await _context.DeviceAuths
                .Where(d => d.ApiKey == apiKey && d.IsActive)
                .FirstOrDefaultAsync();
        }
    }
}
