using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetStateById.Queries.Dto;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.StateMangement.GetStateById.Queries
{
    public record GetStateByIdQuery(string Id) : IRequest<RequestResult<GetByIdStateDto?>>;


    public class GetStateByIdQueryHandler : RequestHandlerBase<GetStateByIdQuery, RequestResult<GetByIdStateDto?>, State>
    {
        public GetStateByIdQueryHandler(RequestHandlerBaseParameters<State> requestHandlerBaseParameters) : base(requestHandlerBaseParameters) { }

        public override async Task<RequestResult<GetByIdStateDto?>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {


            var state = await _repository
                    .GetAll() 
                    .Where(s => s.Id == request.Id)
                    .ProjectToType<GetByIdStateDto>() 
                    .FirstOrDefaultAsync(cancellationToken);

           
            if (state == null)
                return RequestResult<GetByIdStateDto?>.Failure("State is not found", ErrorCode.StateNotFound);

         
            return RequestResult<GetByIdStateDto?>.Success(state);
        }
    }
}
