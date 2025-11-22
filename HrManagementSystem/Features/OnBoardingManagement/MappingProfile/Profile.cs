using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.Common.Branch.AddBranches.Dtos;
using HrManagementSystem.Features.Common.Department.AddDepartments.Dtos;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;
using Mapster;

namespace HrManagementSystem.Features.OnBoardingManagement.MappingProfile
{
    public class Profile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CompaniesDto, Company>()
                .Ignore(dest => dest.Branches);

            config.NewConfig<BranchesDto, Branch>()
                .Ignore(dest => dest.Departments);

            config.NewConfig<DepartmentsDto, Department>()
                .Ignore(dest => dest.Teams);
        }
    }
}
