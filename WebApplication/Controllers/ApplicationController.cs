using Business.DTOs;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var apps = await _applicationService.GetAllAsync();
            return Ok(apps);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateApplicationRequest request)
        {
            var app = await _applicationService.CreateAsync(request);
            return Ok(app);
        }
    }
}
