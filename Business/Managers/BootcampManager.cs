using Business.DTOs;
using Business.Services;
using Core.Enums;
using Entities;
using Repositories.Interfaces;

namespace Business.Managers
{
    public class BootcampManager : IBootcampService
    {
        private readonly IRepository<Bootcamp> _bootcampRepository;

        public BootcampManager(IRepository<Bootcamp> bootcampRepository)
        {
            _bootcampRepository = bootcampRepository;
        }

        public async Task<List<BootcampResponse>> GetAllAsync()
        {
            var list = await _bootcampRepository.GetAllAsync();
            return list.Select(b => new BootcampResponse
            {
                Id = b.Id,
                Name = b.Name,
                State = b.BootcampState.ToString()
            }).ToList();
        }

        public async Task<BootcampResponse> CreateAsync(CreateBootcampRequest request)
        {
            var bootcamp = new Bootcamp
            {
                Name = request.Name,
                InstructorId = request.InstructorId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                BootcampState = BootcampState.Preparing
            };

            await _bootcampRepository.AddAsync(bootcamp);
            await _bootcampRepository.SaveAsync();

            return new BootcampResponse
            {
                Id = bootcamp.Id,
                Name = bootcamp.Name,
                State = bootcamp.BootcampState.ToString()
            };
        }
    }
}
