using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetRequestById;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.Comman.Mapping
{
    public class GetRequestByIdProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)

        {
            // Configure mappings here
            config.NewConfig<Request, GetRequestByIdResponseViewModel>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status);

        }
    }
}
