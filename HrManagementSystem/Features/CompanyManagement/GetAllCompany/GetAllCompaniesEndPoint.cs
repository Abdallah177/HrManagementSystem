using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization;
using Microsoft.AspNetCore.Mvc;
using HrManagementSystem.Features.CompanyManagement.GetAllCompany.Query;
using Mapster;

namespace HrManagementSystem.Features.CompanyManagement.GetAllCompany
{
    public class GetAllCompaniesEndPoint : BaseEndPoint<object, GetAllCompaniesResponseViewModle>
    {
        public GetAllCompaniesEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<List<GetAllCompaniesResponseViewModle>>>  GetAllCompany()
        {
            var result = await _mediator.Send(new GetAllCompaniesQuery());

            if (!result.IsSuccess)
                return new EndpointResponse<List<GetAllCompaniesResponseViewModle>>(default, false, result.Message, result.ErrorCode);

            var CompaniesDate = result.Data.Adapt<List<GetAllCompaniesResponseViewModle>>();
            return EndpointResponse<List<GetAllCompaniesResponseViewModle>>.Success(CompaniesDate);



        }
    }
}
