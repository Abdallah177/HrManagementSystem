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
    public record AddOrganizationCommand(string Name,string UserId):IRequest<RequestResult<bool>>;
    public class AddOrganizationCommandHandler: RequestHandlerBase<AddOrganizationCommand, RequestResult<bool>,Organization>
    {
        

        public AddOrganizationCommandHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters) { }
        
          
        public override async Task<RequestResult<bool>> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
           
            var existResult = await _mediator.Send(new CheckOrganizationExistQuery(request.Name), cancellationToken);
            if (existResult.Data)
                return RequestResult<bool>.Failure("Organization already exists", ErrorCode.OrganizationAlreadyExists);

           
            var organization = request.Adapt<Organization>();
            await _repository.AddAsync(organization,request.UserId,cancellationToken);

            return RequestResult<bool>.Success(true, "Organization created successfully");
        }
    }



}