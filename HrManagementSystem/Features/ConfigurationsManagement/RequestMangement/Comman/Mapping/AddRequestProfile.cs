using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.DTOS;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.Comman.Mapping
{
    public class AddRequestProfile : IRegister
    {
        public AddRequestProfile() { }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddRequestCommand, Request>()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status);

            config.NewConfig<Request, AddRequestDTO>()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status)
                 .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<AddRequestCommand, AddRequestDTO>()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status);

            //---------------------------------------------------------

            config.NewConfig<Request, AddRequestCommand>()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status);

            config.NewConfig<AddRequestDTO, Request>()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<AddRequestDTO, AddRequestCommand>()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Status, src => src.Status);





        }
    }
}
