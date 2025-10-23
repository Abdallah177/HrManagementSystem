using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.CompanyManagement.Common.Query.CheckCompanyExist
{
    public record CheckCompanyExistQuery(string CompanyId):IRequest<RequestResult<bool>>;

    public class CheckCompanyExistQueryHandler : RequestHandlerBase<CheckCompanyExistQuery, RequestResult<bool>,Company>
    {
        public CheckCompanyExistQueryHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(CheckCompanyExistQuery request, CancellationToken cancellationToken)
        {
            var IsCompanyExists = await _repository.IsExistsAsync(c => c.Id == request.CompanyId);

            return RequestResult<bool>.Success(IsCompanyExists);
        }
    }
}
