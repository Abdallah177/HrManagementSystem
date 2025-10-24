using Azure.Core;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace HrManagementSystem.Features.CompanyManagement.UpdateCompany.Queries
{
    public record CheckCompanyExitstWithName (string CompanyName , string CountryId , string OrganizationId) : IRequest<bool>;


    public class CheckCompanyExitstWithNameHandler : RequestHandlerBase<CheckCompanyExitstWithName,bool,Company>
    {
        

        public CheckCompanyExitstWithNameHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
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
