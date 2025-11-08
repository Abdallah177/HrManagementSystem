using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.GenerateScope;
using MediatR;
using System.Threading;
using HrManagementSystem.Common.Entities;
using Microsoft.EntityFrameworkCore;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;

namespace HrManagementSystem.Features.OnBoardingManagement.Queries
{
    public record GetAllCompanyIdsQuery() : IRequest<RequestResult<List<string>>>;

    public class GetAllCompanyIdsQueryHandler : RequestHandlerBase<GetAllCompanyIdsQuery, RequestResult<List<string>>, Company>
    {
        public GetAllCompanyIdsQueryHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<string>>> Handle(GetAllCompanyIdsQuery request, CancellationToken cancellationToken)
        {
            var companies = await _repository
                .GetAll()
                .Select(c => c.Id)
                .ToListAsync(cancellationToken);

            return RequestResult<List<string>>.Success(companies);
        }
    }

}
