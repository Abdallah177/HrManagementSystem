namespace HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Query.DTOS
{
    public class DepartmentDTO
    {
        public string DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string BranchId { get; set; }
        
        public string BranchName { get; set; }


    }
}
