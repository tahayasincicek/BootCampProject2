using Business.DTOs;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlacklistController : ControllerBase
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _blacklistService.GetAllAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlacklistRequest request)
        {
            var result = await _blacklistService.CreateAsync(request);
            return Ok(result);
        }
    }
}
