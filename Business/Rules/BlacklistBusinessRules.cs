using Entities;
using Repositories.Interfaces;

namespace Business.Rules
{
    public class BlacklistBusinessRules
    {
        private readonly IRepository<Blacklist> _blacklistRepository;

        public BlacklistBusinessRules(IRepository<Blacklist> blacklistRepo)
        {
            _blacklistRepository = blacklistRepo;
        }

        public async Task EnsureNoDuplicateActive(int applicantId)
        {
            var exists = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
            if (exists != null)
                throw new Exception("Aynı aday için birden fazla kara liste kaydı olamaz.");
        }

        public void EnsureReasonNotEmpty(string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new Exception("Kara liste sebebi boş olamaz.");
        }
    }
}
