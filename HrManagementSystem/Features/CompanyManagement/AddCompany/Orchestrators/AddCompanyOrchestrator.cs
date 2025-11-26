using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.AddCompany.Commands;
using HrManagementSystem.Features.CompanyManagement.AddCompany.Dtos;
using MediatR;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.Common.Company.CheckCompanyExistsWithName;

namespace HrManagementSystem.Features.CompanyManagement.AddCompany.Orchestrators
{
    public record AddCompanyOrchestrator(string Name, string Email, string CountryId, string OrganizationId, string currentUserId) : IRequest<RequestResult<AddCompanyResponseViewModel>>;

    public class AddCompanyOrchestratorHandler : RequestHandlerBase<AddCompanyOrchestrator, RequestResult<AddCompanyResponseViewModel>, Company>
    {
        public AddCompanyOrchestratorHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<AddCompanyResponseViewModel>> Handle(AddCompanyOrchestrator request, CancellationToken cancellationToken)
        {
            // CheckCountryExists
            var IsCountryExists = await _mediator.Send(new CheckExistsQuery<Country>(request.CountryId));

            if (!IsCountryExists)
                return RequestResult<AddCompanyResponseViewModel>.Failure("Country Not Found", ErrorCode.CountryNotFound);

            // CheckOrganizationExists
            var IsOrganizationExists = await _mediator.Send(new CheckExistsQuery<Organization>(request.OrganizationId));

            if (!IsOrganizationExists)
                return RequestResult<AddCompanyResponseViewModel>.Failure("Organization Not Found", ErrorCode.OrganizationNotExis);

            var isDuplicateCompany = await _mediator.Send(new CheckCompanyExitstWithName(request.Name, request.CountryId, request.OrganizationId));

            if (isDuplicateCompany)
                return RequestResult<AddCompanyResponseViewModel>.Failure("A company with the same name already exists in this country and organization.", ErrorCode.DuplicateRecord);

            var addCompanyResult = await _mediator.Send(new AddCompanyCommand(request.Name,request.Email,request.CountryId,request.OrganizationId,request.currentUserId));
            if()
        }
    }

}
