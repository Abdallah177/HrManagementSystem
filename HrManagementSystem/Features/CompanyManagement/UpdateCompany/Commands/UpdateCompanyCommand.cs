using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.Queries.CheckExists;
using HrManagementSystem.Features.Common.Queries.Company.CheckCompanyExists;
using HrManagementSystem.Features.Common.Queries.Location.Country.CheckCountryExists;
using HrManagementSystem.Features.CompanyManagement.GetCompanyById;
using HrManagementSystem.Features.CompanyManagement.UpdateCompany.Dtos;
using HrManagementSystem.Features.CompanyManagement.UpdateCompany.Queries;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.CompanyManagement.UpdateCompany.Commands
{
    public record UpdateCompanyCommand(string Id, string Name, string Email, string CountryId, string OrganizationId) : IRequest<RequestResult<UpdateCompanyDto>>;


    public class UpdateCompanyCommandHandler : RequestHandlerBase<UpdateCompanyCommand, RequestResult<UpdateCompanyDto>, Company>
    {
        public UpdateCompanyCommandHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<UpdateCompanyDto>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {


            // CheckCompanyExists
            var companyResult = await _mediator.Send(new GetCompanyByIdQuery(request.Id));

            if (!companyResult.IsSuccess)
                return RequestResult<UpdateCompanyDto>.Failure("Company Not Found", ErrorCode.CompanyNotExist);

            // CheckCountryExists
            var IsCountryExists = await _mediator.Send(new CheckCountryExistsQuery(request.CountryId));

            if (!IsCountryExists.IsSuccess)
                return RequestResult<UpdateCompanyDto>.Failure("Country Not Found", ErrorCode.CountryNotFound);

            // CheckOrganizationExists
            var IsOrganizationExists = await _mediator.Send(new CheckExistsQuery<Organization>(request.OrganizationId));

            if (!IsOrganizationExists)
                return RequestResult<UpdateCompanyDto>.Failure("Organization Not Found", ErrorCode.OrganizationNotExis);


            var isDuplicateCompany = await _mediator.Send(new CheckCompanyExitstWithName(request.Name, request.CountryId, request.OrganizationId));

            if (isDuplicateCompany)
                return RequestResult<UpdateCompanyDto>.Failure("A company with the same name already exists in this country and organization.", ErrorCode.DuplicateRecord);

            var company = companyResult.Data.Adapt<Company>();

            company.Name = request.Name;
            company.CountryId = request.CountryId;
            company.OrganizationId = request.OrganizationId;
            company.Email = request.Email;

            await _repository.UpdateIncludeAsync(company, "SYSTEM", cancellationToken, nameof(Company.Name), nameof(Company.Email), nameof(Company.CountryId), nameof(Company.OrganizationId));

            var updateCompanyDto = company.Adapt<UpdateCompanyDto>();

            return RequestResult<UpdateCompanyDto>.Success(updateCompanyDto);
        }

    }

}
