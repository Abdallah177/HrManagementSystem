using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;
using HrManagementSystem.Common;
using Microsoft.EntityFrameworkCore;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Features.ConfigurationsManagement.Common.CheckIsEntityExist.Queries;

namespace HrManagementSystem.Features.ConfigurationsManagement.Common.DeleteConfigrationScope.Commands
{
    public record DeleteConfigurationScopesCommand<TConfiguration, TScope>(string ConfigurationId,string CurrentUserId) : IRequest<RequestResult<bool>>
    where TConfiguration : BaseModel
    where TScope : BaseScope<TConfiguration>;

    public class DeleteConfigurationScopesHandler<TConfiguration, TScope> :
        RequestHandlerBase<DeleteConfigurationScopesCommand<TConfiguration, TScope>, RequestResult<bool>, TScope> where TConfiguration : BaseModel where TScope : BaseScope<TConfiguration>
    {
        public DeleteConfigurationScopesHandler(RequestHandlerBaseParameters<TScope> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteConfigurationScopesCommand<TConfiguration, TScope> request, CancellationToken cancellationToken)
        {
            //check in the configurationScope Entity
            var scopeEntityIsExist = await _mediator.Send(new CheckIsEntityExistQuery<TScope>(s => s.EntityId == request.ConfigurationId && !s.IsDeleted && s.IsActive), cancellationToken);
            if (!scopeEntityIsExist)
                return RequestResult<bool>.Failure($"{typeof(TScope).Name} not found",ErrorCode.NotExist);

            await _repository.DeleteFromAsync(s => s.EntityId == request.ConfigurationId, request.CurrentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, $"Configration Scopes deleted for {typeof(TConfiguration).Name}");
        }


    }
}
