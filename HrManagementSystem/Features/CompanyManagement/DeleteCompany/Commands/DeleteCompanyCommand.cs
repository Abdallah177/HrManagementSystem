using HrManagementSystem.Common;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands
{
    public record DeleteCompanyCommand(string companyId) : IRequest<RequestResult<bool>>;

    public class DeleteCompanyCommandHandler : RequestHandlerBase<DeleteCompanyCommand, RequestResult<bool>,compa>
    {
        public DeleteCompanyCommandHandler()
        {
        }
        public async Task<RequestResult<bool>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
