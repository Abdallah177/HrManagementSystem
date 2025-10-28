using HrManagementSystem.Common.Entities;
using Mapster;

namespace HrManagementSystem.Features.BranchManagement.Common.MappingProfile
{
    public class GetAllBranchesProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Branch, GetAllBranches.GetAllBranchesResponseViewModel>()
             .Map(dest => dest.BranchId, src => src.Id)
             .Map(dest => dest.BranchName, src => src.Name)
             .Map(dest => dest.CompanyId, src => src.CompanyId)
             .Map(dest => dest.CompanyName, src => src.Company.Name)
             .Map(dest => dest.CityId, src => src.CityId)
             .Map(dest => dest.CityName, src => src.City.Name);
        }

    }
}
