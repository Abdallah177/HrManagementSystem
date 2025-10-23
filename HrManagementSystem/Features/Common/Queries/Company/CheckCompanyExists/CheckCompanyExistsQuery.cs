using HrManagementSystem.Common;
using MediatR;

namespace HrManagementSystem.Features.Common.Queries.Company.CheckCompanyExists
{
    public record CheckCompanyExistsQuery (string Id) : IRequest<bool>;

    //public class CheckCompanyExistsQueryHandler : RequestHandlerBase<CheckCompanyExistsQuery, bool, HrManagementSystem.Common.Entities.Company>
    //{
    //    public CheckCompanyExistsQueryHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Company> parameters) : base(parameters)
    //    {
    //    }

    //    public override Task<bool> Handle(CheckCompanyExistsQuery request, CancellationToken cancellationToken)
    //    {
            
    //    }
    //}


}
