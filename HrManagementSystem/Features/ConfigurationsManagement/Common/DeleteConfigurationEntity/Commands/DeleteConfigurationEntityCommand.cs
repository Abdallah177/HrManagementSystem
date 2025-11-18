using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.ConfigurationsManagement.Common.CheckIsEntityExist.Queries;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace HrManagementSystem.Features.ConfigurationsManagement.Common.DeleteConfigrationScope.Commands
{
    public record DeleteConfigurationEntityCommand<TConfiguration>(string ConfigurationId, string CurrentUserId) : 
        IRequest<RequestResult<bool>> where TConfiguration : BaseModel;
    public class DeleteConfigurationEntityCommandHandler<TConfiguration> : 
        RequestHandlerBase<DeleteConfigurationEntityCommand<TConfiguration>, RequestResult<bool>, TConfiguration> where TConfiguration : BaseModel
    {
        public DeleteConfigurationEntityCommandHandler(RequestHandlerBaseParameters<TConfiguration> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteConfigurationEntityCommand<TConfiguration> request, CancellationToken cancellationToken)
        {
            //check In the configurationEntity
            var entityIsExist = await _mediator.Send(new CheckExistsQuery<TConfiguration>(e => e.Id == request.ConfigurationId && !e.IsDeleted && e.IsActive), cancellationToken);
            if (!entityIsExist)
                return RequestResult<bool>.Failure($"{typeof(TConfiguration).Name} not found", ErrorCode.NotExist);

            await _repository.DeleteFromAsync(e => e.Id == request.ConfigurationId, request.CurrentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, $"{typeof(TConfiguration).Name} successfully deleted");
        }
    }
}
