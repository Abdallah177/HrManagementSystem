using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
<<<<<<< HEAD
using HrManagementSystem.Features.Common.Company.CheckCompanyExistsWithName;
=======
using HrManagementSystem.Features.Common.Location.Country.CheckCountryExists;
>>>>>>> master
using HrManagementSystem.Features.CompanyManagement.GetCompanyById;
using HrManagementSystem.Features.CompanyManagement.UpdateCompany.Dtos;
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
            var IsCountryExists = await _mediator.Send(new CheckExistsQuery<Country>(request.CountryId));

            if (!IsCountryExists)
                return RequestResult<UpdateCompanyDto>.Failure("Country Not Found", ErrorCode.CountryNotFound);

            // CheckOrganizationExists
            var IsOrganizationExists = await _mediator.Send(new CheckExistsQuery<Organization>(request.OrganizationId));

            if (!IsOrganizationExists)
                return RequestResult<UpdateCompanyDto>.Failure("Organization Not Found", ErrorCode.OrganizationNotExis);


            var isDuplicateCompany = await _mediator.Send(new CheckCompanyExitstWithName(request.Name, request.CountryId, request.OrganizationId));

            if (isDuplicateCompany)
                return RequestResult<UpdateCompanyDto>.Failure("A company with the same name already exists in this country and organization.", ErrorCode.DuplicateRecord);

            var company = companyResult.Data.Adapt<Company>();

            //var company = await _repository.GetByIDAsync(companyResult.Data.Id);
                      
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
