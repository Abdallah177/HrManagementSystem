using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization.Queries;
using MediatR;
using HrManagementSystem.Features.OrganizationManagement.NewFolder.Dtos;
using HrManagementSystem.Features.OrganizationManagement.NewFolder.Queries;
using Mapster;
using Microsoft.EntityFrameworkCore;
using HrManagementSystem.Features.OrganizationManagement.UpdateOrganization.Queries;

namespace HrManagementSystem.Features.OrganizationManagement.NewFolder.Commands
{
    public record UpdateOrganizationCommand(string Id , string Name)
     : IRequest<RequestResult<UpdateOrganizationDto>>;

    public class UpdateOrganizationCommandHandler
        : RequestHandlerBase<UpdateOrganizationCommand, RequestResult<UpdateOrganizationDto>, Organization>
    {
        public UpdateOrganizationCommandHandler(RequestHandlerBaseParameters<Organization> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<UpdateOrganizationDto>> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            //Check: Organization Exists
            var organizationResult = await _mediator.Send(new GetOrganizationByIdQuery(request.Id));

            if (!organizationResult.IsSuccess)
                return RequestResult<UpdateOrganizationDto>.Failure("Organization Not Found", ErrorCode.OrganizationNotExis);

            //Check: Duplicate Name
            var isDuplicate = await _mediator.Send(new CheckOrganizationExistsByNameQuery(request.Name));

            if (isDuplicate)
                return RequestResult<UpdateOrganizationDto>.Failure("Organization Name Already Exists", ErrorCode.DuplicateRecord);

            var organization = organizationResult.Data.Adapt<Organization>();

            organization.Name = request.Name;

            await _repository.UpdateIncludeAsync(
                organization,
                "SYSTEM",
                cancellationToken,
                nameof(Organization.Name)
            );

            var dto = organization.Adapt<UpdateOrganizationDto>();
            return RequestResult<UpdateOrganizationDto>.Success(dto);
        }
    }



}

