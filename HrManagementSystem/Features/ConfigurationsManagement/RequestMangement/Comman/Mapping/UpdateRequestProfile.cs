using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.Comman.Mapping
{
    public class UpdateRequestProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Add your mapping configurations here
            config.NewConfig<UpdateRequestRequestViewModel, Request>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status);
        }
    }
}
