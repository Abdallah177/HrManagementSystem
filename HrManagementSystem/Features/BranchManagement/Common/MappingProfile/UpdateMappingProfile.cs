using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.BranchManagement.UpdateBranch.Commands;
using HrManagementSystem.Features.BranchManagement.UpdateBranch.DTOs;
using Mapster;

namespace HrManagementSystem.Features.BranchManagement.Common.MappingProfile
{
    public class UpdateMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Branch, UpdateBranchDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.CompanyId, src => src.CompanyId)
                .Map(dest => dest.CityId, src => src.CityId);

            TypeAdapterConfig<UpdateBranchCommand, Branch>
             .NewConfig()
              .Ignore(dest => dest.Id);
        }
    }

}
