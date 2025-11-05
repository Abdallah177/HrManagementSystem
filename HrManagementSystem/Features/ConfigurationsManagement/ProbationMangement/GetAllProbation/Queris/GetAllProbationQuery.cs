using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetAllProbation.DTOs;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetAllProbation.Queris
{
    public record GetAllProbationQuery() : IRequest<RequestResult<List<GetAllProbtionResponseViewModel>>>;

    public class GetAllProbationQueryHandler : RequestHandlerBase<GetAllProbationQuery, RequestResult<List<GetAllProbtionResponseViewModel>>, Probation>
    {
        public GetAllProbationQueryHandler(RequestHandlerBaseParameters<Probation> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<GetAllProbtionResponseViewModel>>> Handle(GetAllProbationQuery request, CancellationToken cancellationToken)
        {
            var probations = await _repository.GetAll()
                .ProjectToType<GetAllProbtionResponseViewModel>()
                .ToListAsync(cancellationToken);

            return RequestResult<List<GetAllProbtionResponseViewModel>>.Success(probations);

        }
    }
}
