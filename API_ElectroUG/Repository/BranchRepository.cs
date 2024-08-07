using API_ElectroUG.Context;
using API_ElectroUG.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace API_ElectroUG.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _context;

        public BranchRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<Models.Branch> CreateBranchAsync(Models.Branch createBranch)
        {
            // Validar que el nombre del branch no esté repetido
            if (await _context.Branch.AnyAsync(b => b.Name == createBranch.Name))
            {
                throw new Exception($"El nombre de la sucursal ya existe. {createBranch.Name}");
            }

            _context.Branch.Add(createBranch);
            await _context.SaveChangesAsync();
            return createBranch;
        }

        public async Task<Models.Branch> DisabledBranchAsync(int id)
        {
            var existsBranch = await _context.Branch.FindAsync(id);

            if (existsBranch != null)
            {
                _context.Entry(existsBranch)
                        .CurrentValues.SetValues(existsBranch.IsDisabled = true);
                await _context.SaveChangesAsync();
                return existsBranch;
            }
            else
            {
                throw new ApiException($"Operación no permitida.", 400, $"No se encontró una sucursal con el id: {id}.");
            }
        }

        public async Task<List<Models.Branch>> GetAllBranchAsync()
        {
            List<Models.Branch> branchs = await _context.Branch
                                        .Where(b => b.IsDisabled != true)
                                        .ToListAsync();

            return branchs;
        }

        public async Task<Models.Branch> GetBranchByIdAsync(int branchId)
        {
            var branch = await _context.Branch
                                       .Where(b => b.BranchId == branchId 
                                        && b.IsDisabled != true)
                                       .FirstOrDefaultAsync();
            return branch;  
        }

        public async Task<Models.Branch> GetBranchByNameAsync(string branchName)
        {
            var branch = await _context.Branch
                                       .Where(b => b.Name == branchName
                                        && b.IsDisabled != true)
                                       .FirstOrDefaultAsync();
            return branch;
        }

        public async Task<List<Models.Branch>> GetBranchByPopularityAsync(int popularity)
        {
            List<Models.Branch> branchs = await _context.Branch
                                                 .Where(b => b.Popularity == popularity 
                                                  && b.IsDisabled != true)
                                                 .ToListAsync();

            return branchs;
        }
        public async Task<Models.Branch> UpdateBranchAsync(int id, Models.Branch updateBranch)
        {
            var existingBranch = await _context.Branch.Where(b => b.BranchId == id 
                                                        && b.IsDisabled != true)
                                                       .FirstOrDefaultAsync();
            if (existingBranch == null)
            {
                throw new Exception($"No se encontró la sucrusal con el id: {id}");
            }

            // Validar que el nuevo nombre no esté en uso por otro branch
            if (await _context.Branch.AnyAsync(b => b.Name == updateBranch.Name && b.BranchId != id))
            {
                throw new Exception($"Ya existe el nombre de la sucrusal: {updateBranch.Name}");
            }

            existingBranch.Name = updateBranch.Name;
            existingBranch.Address = updateBranch.Address;
            existingBranch.Popularity = updateBranch.Popularity;
            existingBranch.IsDisabled = updateBranch.IsDisabled;
            existingBranch.CreationBranch = updateBranch.CreationBranch;

            await _context.SaveChangesAsync();
            return updateBranch;
        }

    }
}
