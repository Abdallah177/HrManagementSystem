using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using MediatR;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;
using HrManagementSystem.Features.CompanyManagement.AddCompany.Dtos;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingOrchestrator(OnBoardingDto OnBoardingDto, string currentUserId) : IRequest<RequestResult<bool>>;

    public class OnBoardingOrchestratorHandler : RequestHandlerBase<OnBoardingOrchestrator, RequestResult<bool>, Organization>
    {
        public OnBoardingOrchestratorHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(OnBoardingOrchestrator request, CancellationToken cancellationToken)
        {
            var organizationResult = await _mediator.Send(new OnBoardingOrgainzationCommand(request.OnBoardingDto.Organization.Name, request.currentUserId), cancellationToken);
            await _mediator.Send(new OnBoardingCompainesCommand(request.OnBoardingDto.Organization.Companies,request.currentUserId));
            return RequestResult<bool>.Success(true);
        }
    }
}
