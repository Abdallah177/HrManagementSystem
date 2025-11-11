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
    public record GetBreaksByIdQuery (string Id) : IRequest<RequestResult<GetBreakByIdDto>>;

    public class GetBreaksByIdQueryHandler : RequestHandlerBase<GetBreaksByIdQuery, RequestResult<GetBreakByIdDto>, Break>
    {
        public GetBreaksByIdQueryHandler(RequestHandlerBaseParameters<Break> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetBreakByIdDto>> Handle(GetBreaksByIdQuery request, CancellationToken cancellationToken)
        {

            var Break =await _repository.GetByIDAsync(request.Id);

            if (Break == null)
                return RequestResult<GetBreakByIdDto>.Failure("Break Not Found.", ErrorCode.BreakNotFound);

            var breakdto = Break.Adapt<GetBreakByIdDto>();

            return RequestResult<GetBreakByIdDto>.Success(breakdto);    
        }
    }



}
