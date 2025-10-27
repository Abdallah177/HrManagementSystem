using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands
{
    public record DeleteCompanyOrchestrator(string companyId) : IRequest<RequestResult<bool>>;

    public class DeleteCompanyOrchestratorHandler : RequestHandlerBase<DeleteCompanyOrchestrator, RequestResult<bool>, Company>
    {
        public DeleteCompanyOrchestratorHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public override Task<RequestResult<bool>> Handle(DeleteCompanyOrchestrator request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
