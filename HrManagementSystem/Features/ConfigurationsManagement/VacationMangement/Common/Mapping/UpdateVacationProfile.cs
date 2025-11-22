using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.UpdateVacation.DTOs;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.Common.Mapping
{
    public class UpdateVacationProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Vacation, UpdateVacationDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Type, src => src.Type)
                .Map(dest => dest.DurationInDays, src => src.DurationInDays)
                .Map(dest => dest.Description, src => src.Description);
        }
    }
}
