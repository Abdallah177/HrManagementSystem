using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetAllBreaks.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManagement.GetAllBreaks.Queries
{
    public record GetAllBreaksQuery : IRequest<RequestResult<List<BreakDto>>>;

    //public class GetAllBreaksQueryHandler : RequestHandlerBase<GetAllBreaksQuery, RequestResult<List<BreakDto>>, Break>
    //{
    //    public GetAllBreaksQueryHandler(RequestHandlerBaseParameters<Break> parameters) : base(parameters)
    //    {
    //    }

    //    public override async Task<RequestResult<List<BreakDto>>> Handle(GetAllBreaksQuery request, CancellationToken cancellationToken)
    //    {
    //        var breaks =await _repository.GetAll().ToListAsync(cancellationToken);

    //        if (!breaks.Any())
    //            return RequestResult<List<BreakDto>>.Failure("Non Break Found.",ErrorCode.NonBreakFound);

    //        var breakDto = breaks.Adapt<>();
    //    }
    //}

}
