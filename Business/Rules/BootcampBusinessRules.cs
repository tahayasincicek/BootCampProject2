using Entities;
using Repositories.Interfaces;

namespace Business.Rules
{
    public class BootcampBusinessRules
    {
        private readonly IRepository<Bootcamp> _bootcampRepository;
        private readonly IRepository<Instructor> _instructorRepository;

        public BootcampBusinessRules(IRepository<Bootcamp> bootRepo, IRepository<Instructor> instRepo)
        {
            _bootcampRepository = bootRepo;
            _instructorRepository = instRepo;
        }

        public void CheckDateOrder(DateTime start, DateTime end)
        {
            if (start >= end)
                throw new Exception("Başlangıç tarihi bitiş tarihinden önce olmalıdır.");
        }

        public async Task EnsureBootcampNameIsUnique(string name)
        {
            var exists = await _bootcampRepository.GetAsync(b => b.Name == name);
            if (exists != null)
                throw new Exception("Bu isimde bir bootcamp zaten var.");
        }

        public async Task EnsureInstructorExists(int instructorId)
        {
            var exists = await _instructorRepository.GetByIdAsync(instructorId);
            if (exists == null)
                throw new Exception("Eğitmen sistemde kayıtlı değil.");
        }

        public async Task EnsureBootcampIsOpen(int bootcampId)
        {
            var bootcamp = await _bootcampRepository.GetByIdAsync(bootcampId);
            if (bootcamp == null || bootcamp.State == "CLOSED")
                throw new Exception("Bu bootcamp’e başvuru alınamaz.");
        }
    }
}
