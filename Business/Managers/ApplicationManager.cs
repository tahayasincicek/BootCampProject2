using Business.DTOs;
using Business.Services;
using Core.Enums;
using Entities;
using Repositories.Interfaces;

namespace Business.Managers
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IRepository<Application> _applicationRepository;

        public ApplicationManager(IRepository<Application> applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<List<ApplicationResponse>> GetAllAsync()
        {
            var list = await _applicationRepository.GetAllAsync();
            return list.Select(a => new ApplicationResponse
            {
                Id = a.Id,
                State = a.ApplicationState.ToString()
            }).ToList();
        }

        public async Task<ApplicationResponse> CreateAsync(CreateApplicationRequest request)
        {
            var app = new Application
            {
                ApplicantId = request.ApplicantId,
                BootcampId = request.BootcampId,
                ApplicationState = ApplicationState.Pending
            };

            await _applicationRepository.AddAsync(app);
            await _applicationRepository.SaveAsync();

            return new ApplicationResponse
            {
                Id = app.Id,
                State = app.ApplicationState.ToString()
            };
        }
    }
}
