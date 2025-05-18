using Entities;
using Repositories.Interfaces;

namespace Business.Rules
{
    public class ApplicationBusinessRules
    {
        private readonly IRepository<Application> _applicationRepository;
        private readonly IRepository<Bootcamp> _bootcampRepository;
        private readonly IRepository<Blacklist> _blacklistRepository;

        public ApplicationBusinessRules(
            IRepository<Application> appRepo,
            IRepository<Bootcamp> bootRepo,
            IRepository<Blacklist> blacklistRepo)
        {
            _applicationRepository = appRepo;
            _bootcampRepository = bootRepo;
            _blacklistRepository = blacklistRepo;
        }

        public async Task EnsureNoDuplicateApplication(int applicantId, int bootcampId)
        {
            var exists = await _applicationRepository.GetAsync(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
            if (exists != null)
                throw new Exception("Aynı bootcamp’e birden fazla başvuru yapılamaz.");
        }

        public async Task EnsureBootcampIsActive(int bootcampId)
        {
            var bootcamp = await _bootcampRepository.GetByIdAsync(bootcampId);
            if (bootcamp == null || bootcamp.State != "ACTIVE")
                throw new Exception("Başvurulan bootcamp aktif değil.");
        }

        public async Task EnsureApplicantNotBlacklisted(int applicantId)
        {
            var blacklist = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
            if (blacklist != null)
                throw new Exception("Aday kara listededir.");
        }

        public void EnsureValidStatusTransition(string current, string target)
        {
            if (current == "CANCELLED" && target == "PENDING")
                throw new Exception("CANCELLED → PENDING geçişi yapılamaz.");
        }
    }
}
