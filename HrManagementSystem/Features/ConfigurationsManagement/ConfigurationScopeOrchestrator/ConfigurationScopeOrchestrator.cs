using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.ConfigurationsManagement.BreakScopeManagement.AddBreakScope.Commands;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;
using HrManagementSystem.Features.ConfigurationsManagement.ScopeMnangement.GetScope.Queries;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator
{
    public record ConfigurationScopeOrchestrator<TConfigScope, TEntity>(ScopeViewModel ViewModel, string ConfigId)
        : IRequest<RequestResult<bool>>
        where TConfigScope : BaseScope<TEntity>, new()
        where TEntity : BaseModel;


    public class ConfigurationScopeOrchestratorHandler<TConfigScope, TEntity>: RequestHandlerBase<
            ConfigurationScopeOrchestrator<TConfigScope, TEntity>,
            RequestResult<bool>,
            TConfigScope>
        where TConfigScope : BaseScope<TEntity>, new()
        where TEntity : BaseModel
    {
        public ConfigurationScopeOrchestratorHandler(
            RequestHandlerBaseParameters<TConfigScope> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(
            ConfigurationScopeOrchestrator<TConfigScope, TEntity> request,
            CancellationToken cancellationToken)
        {

            //var IsConfigIdExist = await _mediator.Send(new CheckExistsQuery<TEntity>(request.ConfigId));

            //if (!IsConfigIdExist)
            //    return RequestResult<bool>.Failure($"Configuration Entity is Not Found",ErrorCode.ConfiguratioEntityNotFound); 

            var scopeIdResponse = await _mediator.Send(
                new GetScopeQuery(
                    request.ViewModel.OrganizationId,
                    request.ViewModel.CompanyId,
                    request.ViewModel.BranchId,
                    request.ViewModel.DepartmentId,
                    request.ViewModel.TeamId
                )
            );

            if (!scopeIdResponse.IsSuccess)
                return RequestResult<bool>.Failure(
                    scopeIdResponse.Message,
                    scopeIdResponse.ErrorCode
                );

            foreach (var scopeId in scopeIdResponse.Data)
            {

                await _mediator.Send(new AddConfigurationScopeCommand<TConfigScope, TEntity>(scopeId, request.ConfigId));
            }

            return RequestResult<bool>.Success(true);
        }
    }

}
