using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.Common.Company.CheckCompanyExistsWithName;
using HrManagementSystem.Features.CompanyManagement.NewFolder.Dtos;
using HrManagementSystem.Features.CompanyManagement.UpdateCompany.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.NewFolder.Commands
{
    public record AddCompanyCommand(string Name, string Email, string CountryId, string OrganizationId) : IRequest<RequestResult<AddCompanyDto>>;

    public class AddCompanyCommandHandler : RequestHandlerBase<AddCompanyCommand, RequestResult<AddCompanyDto>, Company>
    {
        public AddCompanyCommandHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<AddCompanyDto>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            // CheckCountryExists
            var IsCountryExists = await _mediator.Send(new CheckExistsQuery<Country>(request.CountryId));

            if (!IsCountryExists)
                return RequestResult<AddCompanyDto>.Failure("Country Not Found", ErrorCode.CountryNotFound);

            // CheckOrganizationExists
            var IsOrganizationExists = await _mediator.Send(new CheckExistsQuery<Organization>(request.OrganizationId));

            if (!IsOrganizationExists)
                return RequestResult<AddCompanyDto>.Failure("Organization Not Found", ErrorCode.OrganizationNotExis);

            var isDuplicateCompany = await _mediator.Send(new CheckCompanyExitstWithName(request.Name, request.CountryId, request.OrganizationId));

            if (isDuplicateCompany)
                return RequestResult<AddCompanyDto>.Failure("A company with the same name already exists in this country and organization.", ErrorCode.DuplicateRecord);

            var company = new Company
            {
                Name = request.Name,
                CountryId = request.CountryId,
                OrganizationId = request.OrganizationId,
                Email = request.Email
            };

            await _repository.AddAsync(company,"SYSTEM", cancellationToken);

            var addCompantDto = company.Adapt<AddCompanyDto>();

            return RequestResult<AddCompanyDto>.Success(addCompantDto);

        }
    }

}
