using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.AddCountry.Queries;
using HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Commands;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.AddCountry.Commands;

public record AddCountryCommand(string Name, string? Code, string UserId) : IRequest<RequestResult<bool>>;

public class AddCountryCommandHandler : RequestHandlerBase<AddCountryCommand, RequestResult<bool>, Country>
{
    public AddCountryCommandHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
    {
    }

    public async override Task<RequestResult<bool>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
    {
        var isCountryExists = await _mediator.Send(new IsCountryExistsByNameQuery(request.Name));

        if (isCountryExists.Data)
            return RequestResult<bool>.Failure("Country Name is exist befor", ErrorCode.CountryNameIsExist);


        var country = request.Adapt<Country>();

        await _repository.AddAsync(country, request.UserId, cancellationToken);

        return RequestResult<bool>.Success(default, "Country Added Successfully");
    }
}
