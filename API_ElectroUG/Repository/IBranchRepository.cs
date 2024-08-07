using API_ElectroUG.Models;

namespace API_ElectroUG.Repository
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAllBranchAsync();

        Task<Branch> GetBranchByIdAsync(int branchId);

        Task<Branch> GetBranchByNameAsync(string branchName);

        Task<List<Branch>> GetBranchByPopularityAsync(int popularity);

        Task<Branch> CreateBranchAsync(Branch createBranch);

        Task<Branch> UpdateBranchAsync(int id, Branch updateBranch);

        Task <Branch> DisabledBranchAsync (int id);


    }
}
