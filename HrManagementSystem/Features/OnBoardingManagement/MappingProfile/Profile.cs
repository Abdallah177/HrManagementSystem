using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
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
