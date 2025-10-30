using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands
{
    public record DeleteCompanyCommand(string companyId , string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteCompanyCommandHandler : RequestHandlerBase<DeleteCompanyCommand, RequestResult<bool>, Company>
    {
        public DeleteCompanyCommandHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteFromAsync(c => c.Id == request.companyId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true, "company deleted successfully");
        }
    }

}
