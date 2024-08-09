using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SponsorController : Controller, ISponsorRepository
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorController(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        [HttpPost("CreateSponsor")]
        public Task<Sponsor> CreateSponsorAsync([FromBody] Sponsor createSponsor)
        {
            return _sponsorRepository.CreateSponsorAsync(createSponsor);
        }

        [HttpGet("DisabledSponsorById/{sponsorId}")]
        public Task<Sponsor> DisabledSponsorByIdAsync(int sponsorId)
        {
            return _sponsorRepository.DisabledSponsorByIdAsync(sponsorId);
        }

        [HttpGet("GetAllSponsor")]
        public Task<List<Sponsor>> GetAllSponsorAsync()
        {
            return _sponsorRepository.GetAllSponsorAsync();
        }

        [HttpGet("GetSponsorByCreationTime/{creationSponsor}")]
        public Task<List<Sponsor>> GetSponsorByCreationTimeAsync(DateTime creationSponsor)
        {
            return _sponsorRepository.GetSponsorByCreationTimeAsync(creationSponsor);
        }

        [HttpGet("GetSponsorById/{id}")]
        public Task<Sponsor> GetSponsorByIdAsync(int id)
        {
            return _sponsorRepository.GetSponsorByIdAsync(id);
        }

        [HttpGet("GetSponsorByName/{sponsorName}")]
        public Task<Sponsor> GetSponsorByNameAsync(string sponsorName)
        {
            return _sponsorRepository.GetSponsorByNameAsync(sponsorName);
        }

        [HttpPut("UpdateSponsor")]
        public Task<Sponsor> UpdateSponsorAsync([FromBody] Sponsor updateSponsor)
        {
            return _sponsorRepository.UpdateSponsorAsync(updateSponsor);
        }
    }
}
