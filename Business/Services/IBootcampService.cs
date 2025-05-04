using Business.DTOs;

namespace Business.Services
{
    public interface IBootcampService
    {
        Task<List<BootcampResponse>> GetAllAsync();
        Task<BootcampResponse> CreateAsync(CreateBootcampRequest request);
    }
}
