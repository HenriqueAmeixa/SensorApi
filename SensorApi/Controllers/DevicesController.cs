using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorApi.Data;
using SensorApi.DTOs;
using SensorApi.Models;
using SensorApi.Services.Interfaces;

namespace SensorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeviceCreateDto dto)
        {
            var device = await _deviceService.CreateDeviceAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = device.Id }, device);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var devices = await _deviceService.GetAllDevicesAsync();
            return Ok(devices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var device = await _deviceService.GetByIdAsync(id);
            if (device == null) return NotFound();
            return Ok(device);
        }
    }
}
