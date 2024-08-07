namespace API_ElectroUG.Models
{
    public class Branch
    {
        public int BranchId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime CreationBranch {  get; set; }

        public int Popularity { get; set; }

        public bool IsDisabled { get; set; }
    }
}
