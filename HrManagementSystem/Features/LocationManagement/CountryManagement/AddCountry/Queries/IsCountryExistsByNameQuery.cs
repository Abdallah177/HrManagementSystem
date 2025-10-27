using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.AddCountry.Queries;

public record IsCountryExistsByNameQuery(string name) : IRequest<EndpointResponse<bool>>;

public class IsCountryExistsQueryByNameHandler(IGenericRepository<Country> genericRepository) : IRequestHandler<IsCountryExistsByNameQuery, EndpointResponse<bool>>
{
    private readonly IGenericRepository<Country> _genericRepository = genericRepository;

    public async Task<EndpointResponse<bool>> Handle(IsCountryExistsByNameQuery request, CancellationToken cancellationToken)
    {

        var isCountryExists = await _genericRepository.Get(x => x.Name == request.name).AnyAsync(cancellationToken);

        return isCountryExists ?
            EndpointResponse<bool>.Success(default, "country Exist")
            : EndpointResponse<bool>.Failure("CountryNotExist", ErrorCode.CountryNotFound);
    }
}
