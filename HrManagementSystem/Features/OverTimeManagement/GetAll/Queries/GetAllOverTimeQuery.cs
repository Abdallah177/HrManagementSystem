using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Views;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.OverTimeManagement.GetAll.Queries;

public class GetAllOverTimeQuery : IRequest<RequestResult<IEnumerable<GetAllOverTimeDto>>>;


public class GetAllOverTimeQueryHandler : RequestHandlerBase<GetAllOverTimeQuery, RequestResult<IEnumerable<GetAllOverTimeDto>>, OverTime>
{
    public GetAllOverTimeQueryHandler(RequestHandlerBaseParameters<OverTime> parameters) : base(parameters)
    {
        
    }

    public override async Task<RequestResult<IEnumerable<GetAllOverTimeDto>>> Handle(GetAllOverTimeQuery request, CancellationToken cancellationToken)
    {
        var overTimes = await _repository.GetAll().ToListAsync();

        return RequestResult<IEnumerable<GetAllOverTimeDto>>.Success(overTimes.Adapt<IEnumerable<GetAllOverTimeDto>>());

    }
}
