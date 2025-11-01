using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries.Dtos;
using HrManagementSystem.Features.LocationManagement.CityManagement.GetAllCities.Queries;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos;
using MediatR;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries
{
    public record GetAllOrganizationsQuery : IRequest<RequestResult<GetAllOrganizationDto>>;

    public class GetAllOrganizationsQueryHandler : RequestHandlerBase<GetAllOrganizationsQuery, RequestResult<GetAllOrganizationDto>, Organization>
    {
        public GetAllOrganizationsQueryHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<GetAllOrganizationDto>> Handle(GetAllOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organization = await _repository.GetAll()
                .ProjectToType<GetAllOrganizationDto>()
                .FirstOrDefaultAsync(cancellationToken);

            if (organization == null)
                return RequestResult<GetAllOrganizationDto>.Failure("No organization found", ErrorCode.OrganizationNotExis);

            return RequestResult<GetAllOrganizationDto>.Success(organization);
        }
    }
}
