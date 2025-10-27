using Azure.Core;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace HrManagementSystem.Features.Common.Company.CheckCompanyExistsWithName
{
    public record CheckCompanyExitstWithName(string CompanyName, string CountryId, string OrganizationId) : IRequest<bool>;


    public class CheckCompanyExitstWithNameHandler : RequestHandlerBase<CheckCompanyExitstWithName, bool, HrManagementSystem.Common.Entities.Company>
    {


        public CheckCompanyExitstWithNameHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Company> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckCompanyExitstWithName request, CancellationToken cancellationToken)
        {
            var isDuplicateCompany = await _repository.Get(C => C.Name == request.CompanyName && C.CountryId == request.CountryId && C.OrganizationId == request.OrganizationId)
                                                      .AnyAsync(cancellationToken);

            return isDuplicateCompany;
        }
    }


}
