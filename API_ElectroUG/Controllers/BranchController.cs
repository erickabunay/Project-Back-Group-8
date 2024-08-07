using API_ElectroUG.Models;
using API_ElectroUG.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_ElectroUG.Controllers
{
    public class BranchController : Controller , IBranchRepository
    {
        private readonly IBranchRepository _branchRepository;
        public BranchController(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        [HttpPost("CreateBranch")]
        public async Task<Branch> CreateBranchAsync([FromBody] Branch createBranch)
        {
            return await _branchRepository.CreateBranchAsync(createBranch); 
        }

        [HttpDelete("DisabledBranch/{id}")]
        public async Task<Branch> DisabledBranchAsync(int id)
        {
            return await _branchRepository.DisabledBranchAsync(id);
        }

        [HttpGet("GetAllBranch")]
        public async Task<List<Branch>> GetAllBranchAsync()
        {
            return await _branchRepository.GetAllBranchAsync();
        }

        [HttpGet("GetBranchById/{branchId}")]

        public async Task<Branch> GetBranchByIdAsync(int branchId)
        {
            return await _branchRepository.GetBranchByIdAsync(branchId);
        }

        [HttpGet("GetBranchByName/{branchName}")]
        public async Task<Branch> GetBranchByNameAsync(string branchName)
        {
            return await _branchRepository.GetBranchByNameAsync(branchName);
        }

        [HttpGet("GetBranchByPopularity/{popularity}")]
        public async Task<List<Branch>> GetBranchByPopularityAsync(int popularity)
        {
            return await _branchRepository.GetBranchByPopularityAsync(popularity);
        }

        [HttpPut("UpdateBranch/{id}")]
        public async Task<Branch> UpdateBranchAsync(int id, Branch updateBranch)
        {
            return await _branchRepository.UpdateBranchAsync(id, updateBranch);
        }
    }
}
