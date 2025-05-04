using Business.DTOs;

namespace Business.Services
{
    public interface IApplicationService
    {
        Task<List<ApplicationResponse>> GetAllAsync();
        Task<ApplicationResponse> CreateAsync(CreateApplicationRequest request);
    }
}
