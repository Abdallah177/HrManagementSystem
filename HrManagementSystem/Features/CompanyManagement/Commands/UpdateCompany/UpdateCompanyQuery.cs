using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.Queries.Location.Country.CheckCountryExists;
using HrManagementSystem.Features.CompanyManagement.Commands.UpdateCompany.Dtos;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.Commands.UpdateCompany
{
    public record UpdateCompanyQuery (string Id ,string Name ,string Email ,string CountryId ,string OrganizationId) : IRequest<RequestResult<UpdateCompanyDto>>;


    //public class UpdateCompanyQueryHandler : RequestHandlerBase<UpdateCompanyQuery, RequestResult<UpdateCompanyDto>, Company>
    //{
    //    public UpdateCompanyQueryHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
    //    {
    //    }

    //    public override async Task<RequestResult<UpdateCompanyDto>> Handle(UpdateCompanyQuery request, CancellationToken cancellationToken)
    //    {
    //        // CheckCompanyExists


    //        // CheckCountryExists
    //        var IsCountryExists = await _mediator.Send(new CheckCountryExistsQuery(request.CountryId));

    //        if (!IsCountryExists.IsSuccess)
    //            return RequestResult<UpdateCompanyDto>.Failure("Country Not Found", ErrorCode.CountryNotFound);


    //    }
    //}


}
