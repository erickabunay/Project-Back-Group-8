using API_ElectroUG.Context;
using API_ElectroUG.Exceptions;
using API_ElectroUG.Migrations;
using API_ElectroUG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ElectroUG.Repository
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly AppDbContext _context;

        public SponsorRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Sponsor> CreateSponsorAsync(Sponsor createSponsor)
        {
            _context.Patrocinadores.Add(createSponsor);
            await _context.SaveChangesAsync();
            return createSponsor;

        }

        public async Task<Sponsor> DisabledSponsorByIdAsync(int sponsorId)
        {
            var existsSponsor = await _context.Patrocinadores.FindAsync(sponsorId);
            if (existsSponsor != null)
            {
                _context.Entry(existsSponsor)
                        .CurrentValues.SetValues(existsSponsor.IsDisabled = true);
                await _context.SaveChangesAsync();
                return existsSponsor;
            }
            else
            {
                throw new ApiException($"Operación no permitida.", 400, $"No se encontró un patrocinador con el id: {sponsorId}.");
            }
        }

        public async Task<List<Sponsor>> GetAllSponsorAsync()
        {
            List<Sponsor> sponsors = await _context.Patrocinadores
                                                   .Where(p => p.IsDisabled != true)
                                                   .ToListAsync();
            return sponsors;
        }

        public async Task<List<Sponsor>> GetSponsorByCreationTimeAsync(DateTime creationSponsor)
        {
            List<Sponsor> sponsors = await _context.Patrocinadores
                                                  .Where(p => p.IsDisabled != true 
                                                   && p.CreationSponsor.Date == creationSponsor.Date)
                                                  .ToListAsync();
            return sponsors;
        }

        public async Task<Sponsor> GetSponsorByIdAsync(int id)
        {
            var sponsor = await _context.Patrocinadores.Where(p => p.IsDisabled != true && p.SponsorId == id)
                                                        .FirstOrDefaultAsync();

            return sponsor;
        }

        public async Task<Sponsor> GetSponsorByNameAsync(string sponsorName)
        {
            var sponsor = await _context.Patrocinadores.Where(p => p.IsDisabled != true 
                                                        && p.SponsorName == sponsorName)
                                                       .FirstOrDefaultAsync();

            return sponsor;
        }

        public async Task<Sponsor> UpdateSponsorAsync(Sponsor updateSponsor)
        {
            var sponsor = await _context.Patrocinadores.Where(s => s.SponsorId == updateSponsor.SponsorId 
                                                        &&s.IsDisabled != true).FirstOrDefaultAsync();
            if (sponsor == null)
            {
                throw new KeyNotFoundException("Sponsor no encontrado.");
            }

            // Actualizar las propiedades del sponsor
            sponsor.SponsorName = updateSponsor.SponsorName;
            sponsor.WebsiteUrl = updateSponsor.WebsiteUrl;
            sponsor.ContactEmail = updateSponsor.ContactEmail;
            sponsor.IsDisabled = updateSponsor.IsDisabled;
            sponsor.CreationSponsor = updateSponsor.CreationSponsor;

            // Guarda los cambios en la base de datos
            _context.Patrocinadores.Update(sponsor);
            await _context.SaveChangesAsync();

            return sponsor; // Devuelve el sponsor actualizado
        }

    }
}
