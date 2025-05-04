using Business.DTOs;

namespace Business.Services
{
    public interface IBlacklistService
    {
        Task<List<BlacklistResponse>> GetAllAsync();
        Task<BlacklistResponse> CreateAsync(CreateBlacklistRequest request);
    }
}
