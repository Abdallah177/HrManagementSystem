using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.GetCompanyById.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.CompanyManagement.GetCompanyById
{
    public class GetCompanyByIdEndPoint : BaseEndPoint<GetCompanyByIdRequestViewModel,GetCompanyByIdResponseViewModel>
    {
        public GetCompanyByIdEndPoint(EndpointBaseParameters<GetCompanyByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetCompanyByIdResponseViewModel>> GetCompanyById([FromQuery] GetCompanyByIdRequestViewModel request , CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCompanyByIdQuery(request.companyId),cancellationToken);

            if (!result.IsSuccess)
                return new EndpointResponse<GetCompanyByIdResponseViewModel>(default, false, result.Message, result.ErrorCode);

            var CompaniesDate = result.Data.Adapt<GetCompanyByIdResponseViewModel>();
            return EndpointResponse<GetCompanyByIdResponseViewModel>.Success(CompaniesDate);
        }
    }
}
