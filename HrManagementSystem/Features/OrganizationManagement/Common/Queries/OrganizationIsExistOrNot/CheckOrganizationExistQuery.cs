using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.OrganizationManagement.Common.Queries.OrganizationIsExistOrNot
{
    public record CheckOrganizationExistQuery(string Name) : IRequest<RequestResult<bool>>;


    public class CheckOrganizationExistQueryHandler: RequestHandlerBase<CheckOrganizationExistQuery, RequestResult<bool>,Organization>
    {
        
        public CheckOrganizationExistQueryHandler(RequestHandlerBaseParameters<Organization> parameters):base(parameters) { }

       

        public override async Task<RequestResult<bool>> Handle(CheckOrganizationExistQuery request, CancellationToken cancellationToken)
        {
            var exists = await _repository.IsExistsAsync(x => x.Name == request.Name && !x.IsDeleted);
            return RequestResult<bool>.Success(exists);
        }
    }

}
