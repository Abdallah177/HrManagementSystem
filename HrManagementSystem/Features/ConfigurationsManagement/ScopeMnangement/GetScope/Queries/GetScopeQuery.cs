using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using PredicateExtensions;

namespace HrManagementSystem.Features.ConfigurationsManagement.ScopeMnangement.GetScope.Queries
{
    public record GetScopeQuery(string? OrganizationId , string? CompanyId , string? BranchId , string? DepartmentId,string? TeamId) : IRequest<RequestResult<List<string>>>;

    public class GetScopeQueryHandler : RequestHandlerBase<GetScopeQuery, RequestResult<List<string>>, ScopeBase>
    {
        public GetScopeQueryHandler(RequestHandlerBaseParameters<ScopeBase> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<string>>> Handle(GetScopeQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateExtensions.PredicateExtensions.Begin<ScopeBase>(true);

            if (!string.IsNullOrWhiteSpace(request.OrganizationId))
            {
                
                predicate = predicate.And(x => x.OrganizationId == request.OrganizationId);
            }

            if (!string.IsNullOrWhiteSpace(request.CompanyId))
                predicate = predicate.And(x => x.CompanyId == request.CompanyId);

            if (!string.IsNullOrWhiteSpace(request.BranchId))
                predicate = predicate.And(x => x.BranchId == request.BranchId);

            if (!string.IsNullOrWhiteSpace(request.DepartmentId))
                predicate = predicate.And(x => x.DepartmentId == request.DepartmentId);

            if (!string.IsNullOrWhiteSpace(request.TeamId))
                predicate = predicate.And(x => x.TeamId == request.TeamId);

            var ScopeIds =await _repository.Get(predicate).Select(S => S.Id).ToListAsync(cancellationToken);

            return RequestResult<List<string>>.Success(ScopeIds);
        }
    }

}
