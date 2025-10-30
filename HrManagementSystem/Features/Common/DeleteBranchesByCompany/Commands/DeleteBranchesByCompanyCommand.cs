using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using MediatR;

namespace HrManagementSystem.Features.Common.DeleteBranchesByCompany.Commands
{
    public record DeleteBranchesByCompanyCommand(string companyId , string currentUserId) : IRequest<RequestResult<bool>>;

    public class DeleteBranchesByCompanyCommandHandler : RequestHandlerBase<DeleteBranchesByCompanyCommand, RequestResult<bool>, Branch>
    {
        public DeleteBranchesByCompanyCommandHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteBranchesByCompanyCommand request, CancellationToken cancellationToken)
        {
            //var IsCompanyExist = await _mediator.Send(new CheckExistsQuery<Company>(request.companyId));
            //if (!IsCompanyExist) 
            //     return RequestResult<bool>.Failure("Company not found", ErrorCode.CompanyNotExist);

            await _repository.DeleteFromAsync(b => b.CompanyId == request.companyId, request.currentUserId, cancellationToken);
            return RequestResult<bool>.Success(true ,"Branhes deleted successfully");

        }
    }

}
