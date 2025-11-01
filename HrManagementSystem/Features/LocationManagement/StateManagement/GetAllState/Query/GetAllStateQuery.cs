using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState.Query.DTOS;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetAllState.Query
{
    public record GetAllStateQuery : IRequest<RequestResult<List<GetAllStateDTO>>>;
    
    public class GetAllStateQueryHandler : RequestHandlerBase<GetAllStateQuery, RequestResult<List<GetAllStateDTO>>, State>
    {
        public GetAllStateQueryHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<List<GetAllStateDTO>>> Handle(GetAllStateQuery request, CancellationToken cancellationToken)
        {
            var states = await _repository.GetAll()
                .OrderBy(s => s.Name)
                .ProjectToType<GetAllStateDTO>()
                .ToListAsync(cancellationToken);
            if (states == null )
                return RequestResult<List<GetAllStateDTO>>.Failure("No states found", ErrorCode.StateNotFound);

            return RequestResult<List<GetAllStateDTO>>.Success(states);
        }
    }

}
