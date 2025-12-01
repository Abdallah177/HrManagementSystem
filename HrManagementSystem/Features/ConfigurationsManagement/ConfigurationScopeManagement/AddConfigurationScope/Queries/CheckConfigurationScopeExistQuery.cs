using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;
using HrManagementSystem.Common;
using HrManagementSystem.Features.ConfigurationsManagement.BreakScopeManagement.AddBreakScope.Commands;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakScopeManagement.AddBreakScope.Queries
{
    public record CheckConfigurationScopeExistQuery<TConfigScope, TEntity>(string ScopeId, string EntityId)
        : IRequest<bool>
        where TConfigScope : BaseScope<TEntity>, new()
        where TEntity : BaseModel;

    public class CheckConfigurationScopeExistQueryHandler<TConfigScope, TEntity> :
        RequestHandlerBase<CheckConfigurationScopeExistQuery<TConfigScope, TEntity>, bool, TConfigScope>
        where TConfigScope : BaseScope<TEntity>, new()
        where TEntity : BaseModel
    {
        public CheckConfigurationScopeExistQueryHandler(RequestHandlerBaseParameters<TConfigScope> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckConfigurationScopeExistQuery<TConfigScope, TEntity> request, CancellationToken cancellationToken)
        {
            var isExist =await _repository.Get(C => C.ScopeId == request.ScopeId && C.EntityId == request.EntityId).AnyAsync(cancellationToken);

            return isExist ;
        }
    }

}
