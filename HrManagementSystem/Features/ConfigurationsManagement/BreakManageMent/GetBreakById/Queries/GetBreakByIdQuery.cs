using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetBreakById.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetBreakById.Queries
{
    public record GetBreakByIdQuery (string Id) : IRequest<RequestResult<BreakDto>>;

    public class GetBreaksByIdQueryHandler : RequestHandlerBase<GetBreakByIdQuery, RequestResult<BreakDto>, Break>
    {
        public GetBreaksByIdQueryHandler(RequestHandlerBaseParameters<Break> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<BreakDto>> Handle(GetBreakByIdQuery request, CancellationToken cancellationToken)
        {

            var Break =await _repository.GetByIDAsync(request.Id);

            if (Break == null)
                return RequestResult<BreakDto>.Failure("Break Not Found.", ErrorCode.BreakNotFound);

            var breakdto = Break.Adapt<BreakDto>();

            return RequestResult<BreakDto>.Success(breakdto);    
        }
    }



}
