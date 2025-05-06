using Microsoft.AspNetCore.Mvc;
using SensorApi.DTOs;
using SensorApi.Services.Interfaces;

namespace SensorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorReadingsController : ControllerBase
    {
        private readonly ISensorReadingService _readingService;

        public SensorReadingsController(ISensorReadingService readingService)
        {
            _readingService = readingService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SensorReadingCreateDto dto)
        {
            var created = await _readingService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByDevice), new { deviceId = created.DeviceId }, created);
        }

        [HttpGet("device/{deviceId}")]
        public async Task<IActionResult> GetByDevice(Guid deviceId)
        {
            var readings = await _readingService.GetByDeviceIdAsync(deviceId);
            return Ok(readings);
        }
    }
}
