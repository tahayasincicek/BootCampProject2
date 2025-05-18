using Entities;
using Repositories.Interfaces;

namespace Business.Rules
{
    public class ApplicantBusinessRules
    {
        private readonly IRepository<Applicant> _applicantRepository;
        private readonly IRepository<Blacklist> _blacklistRepository;

        public ApplicantBusinessRules(IRepository<Applicant> applicantRepo, IRepository<Blacklist> blacklistRepo)
        {
            _applicantRepository = applicantRepo;
            _blacklistRepository = blacklistRepo;
        }

        public async Task EnsureApplicantIsUniqueByIdentity(string identity)
        {
            var exists = await _applicantRepository.GetAsync(a => a.IdentityNumber == identity);
            if (exists != null)
                throw new Exception("Aynı TC kimlik numarası ile başvuru yapılamaz.");
        }

        public async Task EnsureApplicantIsNotBlacklisted(int applicantId)
        {
            var blacklist = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
            if (blacklist != null)
                throw new Exception("Bu aday kara listededir.");
        }

        public async Task EnsureApplicantExists(int applicantId)
        {
            var exists = await _applicantRepository.GetByIdAsync(applicantId);
            if (exists == null)
                throw new Exception("Aday sistemde kayıtlı değil.");
        }
    }
}
