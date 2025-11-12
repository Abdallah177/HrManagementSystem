using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.OnBoardingManagement.Queries
{
    public record GetAllScopesQuery(string OrganizationId): IRequest<RequestResult<List<ScopeBaseDto>>>;
    public class GetAllScopesQueryHandler : RequestHandlerBase<GetAllScopesQuery, RequestResult<List<ScopeBaseDto>>, Company>
    {
        public GetAllScopesQueryHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<ScopeBaseDto>>> Handle(GetAllScopesQuery request, CancellationToken cancellationToken)
        {
            var scopesData = await _repository.GetAll()
              .SelectMany(c => c.Branches
              .SelectMany(b => b.Departments 
              .SelectMany(d => d.Teams       
                 .Select(t => new ScopeBaseDto
                 {
                     OrganizationId = request.OrganizationId,
                     CompanyId = c.Id,
                     BranchId = b.Id,
                     DepartmentId = d.Id,
                     TeamId = t.Id
                 })
                )
              )).ToListAsync();

            return RequestResult<List<ScopeBaseDto>>.Success(scopesData);
        }
    }

}
