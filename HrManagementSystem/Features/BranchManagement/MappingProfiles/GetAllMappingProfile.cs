using HrManagementSystem.Common.Entities;
using HrManagementSystem.Features.BranchManagement.Commands.AddBranch;
using HrManagementSystem.Features.BranchManagement.Commands.AddBranch.Commands;
using HrManagementSystem.Features.BranchManagement.Commands.AddBranch.DTOS;
using Mapster;

namespace HrManagementSystem.Features.BranchManagement.MappingProfiles
{
    public class GetAllMappingProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Command → Entity
            config.NewConfig<AddBranchCommand, Branch>()
                .Map(dest => dest.Id, _ => Guid.NewGuid().ToString()) 
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.CityId, src => src.CityId)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.CompanyId, src => src.CompanyId);
              config.NewConfig<AddBranchCommand, Branch>()
                .Map(dest => dest.Id, _ => Guid.NewGuid().ToString()) 
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.CityId, src => src.CityId)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.CompanyId, src => src.CompanyId);
            // Entity → DTO
            config.NewConfig<Branch, AddBranchDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.CityId, src => src.CityId)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.CompanyId, src => src.CompanyId);

            // ViewModel → Command
            config.NewConfig<AddBranchRquestViewModel, AddBranchCommand>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.CityId, src => src.CityId)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.CompanyId, src => src.CompanyId)
                .Map(dest => dest.UserId, src => src.UserId);

            // DTO → ResponseViewModel
            config.NewConfig<AddBranchDTO, AddBranchResponseViewModel>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.CityId, src => src.CityId)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.CompanyId, src => src.CompanyId)
                .Map(dest => dest.UserId, _ => string.Empty); 
        }
    }
}
