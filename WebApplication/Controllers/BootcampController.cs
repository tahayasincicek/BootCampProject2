using Business.DTOs;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _bootcampService.GetAllAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBootcampRequest request)
        {
            var result = await _bootcampService.CreateAsync(request);
            return Ok(result);
        }
    }
}
