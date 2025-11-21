using Azure.Core;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DisabilityManagement.GetDisabilityById.Dtos;
using HrManagementSystem.Features.DisabilityManagement.UpdateDisability.Commands;
using MediatR;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Query.DTOS;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.DisabilityManagement.GetDisabilityById.Queries
{
    public record GetDisabilityByIdQuery(string Id): IRequest<RequestResult<GetDisabilityByIdDto>>;

    public class GetDisabilityByIdQueryHandler : RequestHandlerBase<GetDisabilityByIdQuery, RequestResult<GetDisabilityByIdDto>, Disability>
    {
        public GetDisabilityByIdQueryHandler(RequestHandlerBaseParameters<Disability> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<GetDisabilityByIdDto>> Handle(GetDisabilityByIdQuery request, CancellationToken cancellationToken)
        {
            var disabilityEntity = await _repository.Get(d => d.Id == request.Id)
               .ProjectToType<GetDisabilityByIdDto>()
               .FirstOrDefaultAsync(cancellationToken);

            if (disabilityEntity == null)
                return RequestResult<GetDisabilityByIdDto>.Failure("Disability type not found", ErrorCode.DisabilityTypeNotExist);

            return RequestResult<GetDisabilityByIdDto>.Success(disabilityEntity);
        }
    }

}
