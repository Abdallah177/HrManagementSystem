using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries.Dtos;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries.Dtos;
using Mapster;

namespace HrManagementSystem.Features.BranchManagement.MappingProfile
{
    public class Profile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Branch, BranchDto>()
             .Map(dest => dest.BranchId, src => src.Id)
             .Map(dest => dest.BranchName, src => src.Name);
        }
    }
}
