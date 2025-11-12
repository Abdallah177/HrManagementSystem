using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using MediatR;
using Mapster;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingOrgainzationCommand(string Name , string currentUserId) : IRequest<RequestResult<string>>;

    public class OnBoardingOrgainzationCommandHandler : RequestHandlerBase<OnBoardingOrgainzationCommand, RequestResult<string>, Organization>
    {
        public OnBoardingOrgainzationCommandHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public async  override Task<RequestResult<string>> Handle(OnBoardingOrgainzationCommand request, CancellationToken cancellationToken)
        {
            var organization = request.Adapt<Organization>();
            await _repository.AddAsync(organization, request.currentUserId , cancellationToken);
            return RequestResult<string>.Success(organization.Id , "organization added Successfully");

        }
    }

}
