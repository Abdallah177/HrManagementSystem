using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Views;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetAllRequests.Query
{
    public record GetAllRequestQuery() : IRequest<RequestResult<List<GetAllRequestResponseViewModel>>>;

    public class GetAllRequestQueryHandler : RequestHandlerBase<GetAllRequestQuery, RequestResult<List<GetAllRequestResponseViewModel>>,Request>
    {
        public GetAllRequestQueryHandler(RequestHandlerBaseParameters<Request> parameters) : base(parameters)
        {
        }
        public override async Task<RequestResult<List<GetAllRequestResponseViewModel>>> Handle(GetAllRequestQuery request, CancellationToken cancellationToken)
        {
            var requests = await _repository.GetAll()
                .ProjectToType<GetAllRequestResponseViewModel>()
                .ToListAsync(cancellationToken);

            return RequestResult<List<GetAllRequestResponseViewModel>>.Success(requests);
        }
    }

}
