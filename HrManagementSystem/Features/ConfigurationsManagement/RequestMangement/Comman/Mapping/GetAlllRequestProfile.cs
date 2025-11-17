using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetAllRequests;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.Comman.Mapping
{
    public class GetAlllRequestProfile : IRegister

    {
        public void Register(TypeAdapterConfig config)
        {
            // Configure mappings here

            config.NewConfig<Request, GetAllRequestResponseViewModel>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Tittle, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status);

        }
    }
}
