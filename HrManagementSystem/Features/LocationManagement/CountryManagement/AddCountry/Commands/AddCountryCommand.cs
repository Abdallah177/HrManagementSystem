using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.AddCountry.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.AddCountry.Commands;

public record AddCountryCommand(string Name,string? Code) : IRequest<EndpointResponse<bool>>;

public class AddCountryHandler(IGenericRepository<Country> genericRepository,IMediator mediator) : IRequestHandler<AddCountryCommand, EndpointResponse<bool>>
{
    private readonly IGenericRepository<Country> _genericRepository = genericRepository;
    private readonly IMediator _mediator = mediator;

    public async Task<EndpointResponse<bool>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
    {
        var isCountryExists = await _mediator.Send(new IsCountryExistsByNameQuery(request.Name));

        if (isCountryExists.IsSuccess)
            return isCountryExists;

        var country = new Country { Name = request.Name, Code = request.Code};

        await _genericRepository.AddAsync(country, cancellationToken);

        return EndpointResponse<bool>.Success(default, "Country Added Successfully");
    }
}
