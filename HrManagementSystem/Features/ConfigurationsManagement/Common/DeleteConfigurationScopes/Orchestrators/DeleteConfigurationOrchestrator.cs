using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.Common.DeleteConfigrationScope.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace HrManagementSystem.Features.ConfigurationsManagement.Common.DeleteConfigrationScope.Orchestrators
{
    public record DeleteConfigurationOrchestrator<TConfiguration, TScope>
         (string ConfigurationId, string CurrentUserId) : IRequest<RequestResult<bool>>
         where TConfiguration : BaseModel where TScope : BaseScope<TConfiguration>;

    public class DeleteConfigurationOrchestratorHandler<TConfiguration, TScope> :
        RequestHandlerBase<DeleteConfigurationOrchestrator<TConfiguration, TScope>, RequestResult<bool>, TConfiguration>
        where TConfiguration : BaseModel where TScope : BaseScope<TConfiguration>
    {
        public DeleteConfigurationOrchestratorHandler(RequestHandlerBaseParameters<TConfiguration> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteConfigurationOrchestrator<TConfiguration, TScope> request, CancellationToken cancellationToken)
        {
            var scopeDeleteResult = await _mediator.Send(new DeleteConfigurationScopesCommand<TConfiguration, TScope>(request.ConfigurationId, request.CurrentUserId), cancellationToken);

            if (!scopeDeleteResult.IsSuccess)
                return RequestResult<bool>.Failure(scopeDeleteResult.Message, scopeDeleteResult.ErrorCode);

            var entityDeleteResult = await _mediator.Send(new DeleteConfigurationEntityCommand<TConfiguration>(request.ConfigurationId, request.CurrentUserId), cancellationToken);

            if (!entityDeleteResult.IsSuccess)
                return RequestResult<bool>.Failure(entityDeleteResult.Message, entityDeleteResult.ErrorCode);

            return RequestResult<bool>.Success(true , $"{typeof(TConfiguration).Name} configuration and all scope assignments deleted successfully");
        }
    }
}

