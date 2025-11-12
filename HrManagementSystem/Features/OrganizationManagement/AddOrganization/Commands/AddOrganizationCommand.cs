using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OrganizationManagement.Common.Queries.OrganizationIsExistOrNot;
using MediatR;
using Mapster;

namespace HrManagementSystem.Features.OrganizationManagement.AddOrganization.Commands
{
    public record AddOrganizationCommand(string Name, string UserId) : IRequest<RequestResult<string>>;
    public class AddOrganizationCommandHandler : RequestHandlerBase<AddOrganizationCommand, RequestResult<string>, Organization>
    {


        public AddOrganizationCommandHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters) { }


        public override async Task<RequestResult<string>> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = request.Adapt<Organization>();
            await _repository.AddAsync(organization, request.UserId, cancellationToken);

            return RequestResult<string>.Success(organization.Id, "Organization created successfully");
        }
    }



}