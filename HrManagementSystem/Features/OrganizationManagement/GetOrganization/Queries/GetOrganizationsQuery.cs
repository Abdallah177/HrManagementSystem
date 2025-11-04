using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries.Dtos;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries;
using HrManagementSystem.Features.OrganizationManagement.GetOrganization.Queries.Dtos;
using MediatR;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.OrganizationManagement.GetOrganization.Queries
{
    public record GetOrganizationsQuery : IRequest<RequestResult<GetOrganizationDto>>;

    public class GetOrganizationsQueryHandler : RequestHandlerBase<GetOrganizationsQuery, RequestResult<GetOrganizationDto>, Organization>
    {
        public GetOrganizationsQueryHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<GetOrganizationDto>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {

            var organization = await _repository.GetAll()
                .ProjectToType<GetOrganizationDto>()
                .FirstOrDefaultAsync(cancellationToken);

            if (organization == null)
                return RequestResult<GetOrganizationDto>.Failure("No organization found", ErrorCode.NoOrganizationFound);

            return RequestResult<GetOrganizationDto>.Success(organization);
        }
    }
}
