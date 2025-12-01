using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;
using HrManagementSystem.Common;
using HrManagementSystem.Features.ConfigurationsManagement.BreakScopeManagement.AddBreakScope.Queries;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakScopeManagement.AddBreakScope.Commands
{
    public record AddConfigurationScopeCommand<TConfigScope, TEntity> (string ScopeId ,string EntityId)
        : IRequest<RequestResult<bool>>
        where TConfigScope : BaseScope<TEntity>, new()
        where TEntity : BaseModel;

    public class AddConfigurationScopeCommandHandler<TConfigScope, TEntity> :
        RequestHandlerBase<AddConfigurationScopeCommand<TConfigScope, TEntity>, RequestResult<bool>, TConfigScope>
        where TConfigScope : BaseScope<TEntity>, new()
        where TEntity : BaseModel
    {
        public AddConfigurationScopeCommandHandler(RequestHandlerBaseParameters<TConfigScope> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(AddConfigurationScopeCommand<TConfigScope, TEntity> request, CancellationToken cancellationToken)
        {
            var configScope = new TConfigScope
            {
                ScopeId = request.ScopeId,
                EntityId = request.EntityId
            };

            var IsExist =await _mediator.Send(new CheckConfigurationScopeExistQuery<TConfigScope, TEntity>(request.ScopeId,request.EntityId));

            if (!IsExist) 
            await _repository.AddAsync(configScope, "System", cancellationToken);

            return RequestResult<bool>.Success(true);
        }
    }





}
