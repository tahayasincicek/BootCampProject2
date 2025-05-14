using AutoMapper;
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
        private readonly IMapper _mapper;

        public ApplicationManager(IRepository<Application> applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<List<ApplicationResponse>> GetAllAsync()
        {
            var list = await _applicationRepository.GetAllAsync();

            // BOZULMADI, SADECE AutoMapper ile dönüştürüldü
            return _mapper.Map<List<ApplicationResponse>>(list);
        }

        public async Task<ApplicationResponse> CreateAsync(CreateApplicationRequest request)
        {
            // Request → Entity
            var app = _mapper.Map<Application>(request);

            // Mevcut kural: Başvuru durumu Pending
            app.ApplicationState = ApplicationState.Pending;

            await _applicationRepository.AddAsync(app);
            await _applicationRepository.SaveAsync();

            // Entity → Response DTO
            return _mapper.Map<ApplicationResponse>(app);
        }
    }
}
