using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetProbationById.DTOs;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.Common.Mapping
{
    public class UpdateProbationProfile : IRegister
    {

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Probation, GetProbationByIDDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.DurationInDays, src => src.DurationInDays)
                .Map(dest => dest.EvaluationCriteria, src => src.EvaluationCriteria);

                
        }
    }
}
