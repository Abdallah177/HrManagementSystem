using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.Common.Company.CheckCompanyExistsWithName;
using HrManagementSystem.Features.CompanyManagement.AddCompany.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.AddCompany.Commands
{
    public record AddCompanyCommand(string Name, string Email, string CountryId, string OrganizationId , string currentUserId) : IRequest<RequestResult<AddCompanyDto>>;

    public class AddCompanyCommandHandler : RequestHandlerBase<AddCompanyCommand, RequestResult<AddCompanyDto>, Company>
    {
        public AddCompanyCommandHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<AddCompanyDto>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {

            var company = request.Adapt<Company>();

            await _repository.AddAsync(company,request.currentUserId, cancellationToken);

            var addCompantDto = company.Adapt<AddCompanyDto>();

            return RequestResult<AddCompanyDto>.Success(addCompantDto);

        }
    }

}
