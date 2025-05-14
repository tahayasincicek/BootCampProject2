using Business.DTOs;
using Business.Services;
using Entities;
using Repositories.Interfaces;

namespace Business.Managers
{
    public class BlacklistManager : IBlacklistService
    {
        private readonly IRepository<Blacklist> _blacklistRepository;

        public BlacklistManager(IRepository<Blacklist> blacklistRepository)
        {
            _blacklistRepository = blacklistRepository;
        }

        public async Task<List<BlacklistResponse>> GetAllAsync()
        {
            var list = await _blacklistRepository.GetAllAsync();
            return list.Select(b => new BlacklistResponse
            {
                Id = b.Id,
                Reason = b.Reason,
                Date = b.Date
            }).ToList();
        }

        public async Task<BlacklistResponse> CreateAsync(CreateBlacklistRequest request)
        {
            var blacklist = new Blacklist
            {
                Reason = request.Reason,
                Date = request.Date,
                ApplicantId = request.ApplicantId
            };

            await _blacklistRepository.AddAsync(blacklist);
            await _blacklistRepository.SaveAsync();

            return new BlacklistResponse
            {
                Id = blacklist.Id,
                Reason = blacklist.Reason,
                Date = blacklist.Date
            };
        }
    }
}
