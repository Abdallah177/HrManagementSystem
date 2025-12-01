using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PredicateExtensions;
using System.Threading;
using System;

namespace HrManagementSystem.Features.ConfigurationsManagement.ScopeMnangement.GetScope.Queries
{
    public record GetScopeQuery(OrganizationViewModel OrganizationViewModel)
        : IRequest<RequestResult<List<string>>>;

    public class GetScopeQueryHandler
        : RequestHandlerBase<GetScopeQuery, RequestResult<List<string>>, ScopeBase>
    {
        public GetScopeQueryHandler(RequestHandlerBaseParameters<ScopeBase> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<List<string>>> Handle(GetScopeQuery request, CancellationToken cancellationToken)
        {
            var org = request.OrganizationViewModel;

            var predicate = PredicateExtensions.PredicateExtensions.Begin<ScopeBase>(true);

            // شرط OrganizationId لو موجود
            if (!string.IsNullOrWhiteSpace(org.OrganizationId))
            {
                predicate = predicate.And(x => x.OrganizationId == org.OrganizationId);
            }

            foreach (var company in org.companyViewModel ?? Enumerable.Empty<CompanyViewModel?>())
            {
                if (company == null) continue;

                // لكل شركة نبني شرطها الخاص
                var companyPredicate = PredicateExtensions.PredicateExtensions.Begin<ScopeBase>(true);

                if (!string.IsNullOrEmpty(company.CompanyId))
                    companyPredicate = companyPredicate.And(x => x.CompanyId == company.CompanyId);

                foreach (var branch in company.barnchViewModel ?? Enumerable.Empty<BranchViewModel?>())
                {
                    if (branch == null) continue;

                    var branchPredicate = companyPredicate;

                    if (!string.IsNullOrEmpty(branch.BranchId))
                        branchPredicate = branchPredicate.And(x => x.BranchId == branch.BranchId);

                    foreach (var dept in branch.departmentViewModels ?? Enumerable.Empty<DepartmentViewModel>())
                    {
                        if (dept == null) continue;

                        var deptPredicate = branchPredicate;

                        if (!string.IsNullOrEmpty(dept.DepartmentId))
                            deptPredicate = deptPredicate.And(x => x.DepartmentId == dept.DepartmentId);

                        foreach (var team in dept.teamViewModel ?? Enumerable.Empty<TeamViewModel?>())
                        {
                            if (team == null) continue;

                            var teamPredicate = deptPredicate;

                            if (!string.IsNullOrEmpty(team.TeamId))
                                teamPredicate = teamPredicate.And(x => x.TeamId == team.TeamId);

                            // دمج الشرط النهائي مع الـ predicate العام باستخدام OR
                            predicate = predicate.Or(teamPredicate);
                        }

                        // لو مافيش فريق في القسم، نعتبر القسم كحد أدنى
                        if (dept.teamViewModel == null || !dept.teamViewModel.Any())
                        {
                            predicate = predicate.Or(deptPredicate);
                        }
                    }

                    // لو مافيش أقسام في الفرع، نعتبر الفرع كحد أدنى
                    if (branch.departmentViewModels == null || !branch.departmentViewModels.Any())
                    {
                        predicate = predicate.Or(branchPredicate);
                    }
                }

                // لو مافيش فروع في الشركة، نعتبر الشركة كحد أدنى
                if (company.barnchViewModel == null || !company.barnchViewModel.Any())
                {
                    predicate = predicate.Or(companyPredicate);
                }
            }

            var scopeIds = await _repository
                .Get(predicate)
                .Select(s => s.Id)
                .ToListAsync(cancellationToken);

            return RequestResult<List<string>>.Success(scopeIds);
        }

    }

}


