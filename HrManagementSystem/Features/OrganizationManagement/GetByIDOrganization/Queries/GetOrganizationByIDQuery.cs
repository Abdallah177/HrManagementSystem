using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.DTOs;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.Queries
{
    public record GetOrganizationByIDQuery(string organizationId) : IRequest<RequestResult<GetOrganizationByIDDto>>;

    public class GetOrganizationByIDQueryHandler : RequestHandlerBase<GetOrganizationByIDQuery, RequestResult<GetOrganizationByIDDto>, Organization>
    {
        public GetOrganizationByIDQueryHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetOrganizationByIDDto>> Handle(GetOrganizationByIDQuery request, CancellationToken cancellationToken)
        {
            var organization = await _repository.GetAll().Where(o =>o.Id == request.organizationId)
                                                .ProjectToType<GetOrganizationByIDDto>()
                                                .FirstOrDefaultAsync(cancellationToken);

            if (organization == null)
                return RequestResult<GetOrganizationByIDDto>.Failure("The Organization ID was not found.",ErrorCode.OrganizationIDNotFound);

            return RequestResult<GetOrganizationByIDDto>.Success(organization);
        }
    }

}
