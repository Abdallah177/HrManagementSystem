using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetRequestById.DTOS;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetRequestById.Query
{
    public record GetRequestByIdQuery(string Id) : IRequest<RequestResult<GetRequestByIdDTO>>;

    public class GetRequestByIdQueryHandler : RequestHandlerBase<GetRequestByIdQuery, RequestResult<GetRequestByIdDTO>, Request>
    {
        public GetRequestByIdQueryHandler(RequestHandlerBaseParameters<Request> parameters) : base(parameters)
        { }
        public override async Task<RequestResult<GetRequestByIdDTO>> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var requestEntity = await _repository.GetByIDAsync(request.Id, cancellationToken);

            if (requestEntity == null)
                return RequestResult<GetRequestByIdDTO>.Failure("The requested Request was not found.",ErrorCode.RequestNotFound);
            var requestDto = requestEntity.Adapt<GetRequestByIdDTO>();
     
            return RequestResult<GetRequestByIdDTO>.Success(requestDto);
        }
    }




}
