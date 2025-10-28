using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Query.DTOS;
using Mapster;

namespace HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Mapping
{
    public class MappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Entity → DTO
            config.NewConfig<Department, DepartmentDTO>()
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.BranchId, src => src.BranchId)
                .Map(dest => dest.BranchName, src => src.Branch.Name);

            // DTO → Response ViewModel
            config.NewConfig<DepartmentDTO, GetDepartmentByIdResponseViewModel>()
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.BranchId, src => src.BranchId)
                .Map(dest => dest.BranchName, src => src.BranchName);
        }
    }
}
