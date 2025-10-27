using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.OrganizationManagement.UpdateOrganization.Queries
{
    public record CheckOrganizationExistsByNameQuery (string Name) : IRequest<bool>;

    public class CheckOrganizationExistswithNameHandler : RequestHandlerBase<CheckOrganizationExistsByNameQuery, bool, Organization>
    {
        public CheckOrganizationExistswithNameHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckOrganizationExistsByNameQuery request, CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.ToLower().Trim();

            var isDuplicated = await _repository.Get(o => o.Name.ToLower() == normalizedName).AnyAsync(cancellationToken);

            return isDuplicated;
        }
    }


}
