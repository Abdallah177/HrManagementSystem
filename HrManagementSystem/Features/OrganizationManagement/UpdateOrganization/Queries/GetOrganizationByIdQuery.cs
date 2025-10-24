using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using MediatR;
using HrManagementSystem.Features.OrganizationManagement.NewFolder.Dtos;
using Mapster;

namespace HrManagementSystem.Features.OrganizationManagement.NewFolder.Queries
{
    public record GetOrganizationByIdQuery(string Id)
    : IRequest<RequestResult<OrganizationDto>>;

    public class GetOrganizationByIdQueryHandler
        : RequestHandlerBase<GetOrganizationByIdQuery, RequestResult<OrganizationDto>, Organization>
    {
        public GetOrganizationByIdQueryHandler(RequestHandlerBaseParameters<Organization> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<OrganizationDto>> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _repository.GetByIDAsync(request.Id, cancellationToken);

            if (organization == null)
                return RequestResult<OrganizationDto>.Failure(
                    "Organization does not exist.",
                    ErrorCode.OrganizationNotExis
                );

            var organizationDto = organization.Adapt<OrganizationDto>();

            return RequestResult<OrganizationDto>.Success(organizationDto);
        }
    }


}
