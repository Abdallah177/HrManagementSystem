using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry.Commands
{
    public class UdateCountryCommand : IRequest<RequestResult<Country>>
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public string UpdatedByUser { get; set; } = string.Empty;
    }


    public class UpdateCountryCommandHandler : RequestHandlerBase<UdateCountryCommand, RequestResult<Country>>
    {
        private readonly IGenericRepository<Country> _countryRepository;
        public UpdateCountryCommandHandler(RequestHandlerBaseParameters parameters, IGenericRepository<Country> countryRepository) : base(parameters)
        {
            _countryRepository = countryRepository;
        }

        public override async Task<RequestResult<Country>> Handle(UdateCountryCommand request, CancellationToken cancellationToken)
        {

            // Will Be Refactor After Making GetByIdCrud
            var country = await _countryRepository.GetByIDAsync(request.Id);
            if (country == null)
                return RequestResult<Country>.Failure("Country not found", ErrorCode.CountryNotFound);


            request.Adapt(country);

           
            country.UpdatedByUser = request.UpdatedByUser;
            country.UpdatedAt = DateTime.UtcNow;

            
             _countryRepository.Update(country, request.UpdatedByUser);

            
            return RequestResult<Country>.Success(country, "Country updated successfully");
        }


    }
}
