using API_ElectroUG.Models;

namespace API_ElectroUG.Repository
{
    public interface ISponsorRepository
    {
        Task<List<Sponsor>> GetAllSponsorAsync();

        Task<Sponsor> GetSponsorByIdAsync(int id);

        Task<Sponsor> GetSponsorByNameAsync(string sponsorName);

        Task<List<Sponsor>> GetSponsorByCreationTimeAsync(DateTime creationSponsor);

        Task<Sponsor> CreateSponsorAsync(Sponsor createSponsor);

        Task<Sponsor> UpdateSponsorAsync(Sponsor updateSponsor);

        Task<Sponsor> DisabledSponsorByIdAsync(int sponsorId);
    }
}
