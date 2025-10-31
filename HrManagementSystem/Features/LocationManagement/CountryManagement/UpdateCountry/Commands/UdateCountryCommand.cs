using Azure.Core;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.UpdateCompany;
using HrManagementSystem.Features.DepartmentManagement.UpdateDepartmet.Dtos;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Queries.GetCountryById.Queries;
using HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry.Commands
{
    public class UdateCountryCommand : IRequest<RequestResult<UpdateCountryDto>>
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public string UpdatedByUser { get; set; } = string.Empty;
    }


    public class UpdateCountryCommandHandler : RequestHandlerBase<UdateCountryCommand, RequestResult<UpdateCountryDto>, Country>
    {
        public UpdateCountryCommandHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {

        }

        public async  override Task<RequestResult<UpdateCountryDto>> Handle(UdateCountryCommand request, CancellationToken cancellationToken)
        {
            // Will Be Refactor After Making GetByIdCrud
            var countryQuery = await _mediator.Send(new GetCountryByIdQuery(request.Id));

            if (!countryQuery.IsSuccess)
                return RequestResult<UpdateCountryDto>.Failure("Country not found", ErrorCode.CountryNotFound);

            var country = countryQuery.Data.Adapt<Country>();

            request.Adapt(country);

            await _repository.UpdateIncludeAsync(
                country,
                request.UpdatedByUser,
                cancellationToken,
                nameof(Country.Name),
                nameof(Country.Code)
            );

            var result = country.Adapt<UpdateCountryDto>();

            // _repository.Update(country, request.UpdatedByUser);

            return RequestResult<UpdateCountryDto>.Success(result, "Country updated successfully");
        }
    }
}
