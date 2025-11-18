using Azure.Core;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.AddCountry.Queries
{

    public record IsCountryExistsByNameQuery(string name) : IRequest<RequestResult<bool>>;

    public class IsCountryExistsQueryByNameHandler : RequestHandlerBase<IsCountryExistsByNameQuery, RequestResult<bool>, Country>
    {
        public IsCountryExistsQueryByNameHandler(RequestHandlerBaseParameters<Country> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(IsCountryExistsByNameQuery request, CancellationToken cancellationToken)
        {
            var isCountryExists = await _repository.IsExistsAsync(x => x.Name == request.name , cancellationToken);

            return RequestResult<bool>.Success(isCountryExists);

        }
    }


}