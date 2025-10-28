using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.GetAllCompany.Dto;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.CompanyManagement.GetAllCompany.Query
{
    public class GetAllCompaniesQuery: IRequest<RequestResult<List< CompanyDto>>>;

    public class GetAllCompaniesHandler : RequestHandlerBase<GetAllCompaniesQuery, RequestResult<List<CompanyDto>>, Company>
    {
        public GetAllCompaniesHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters) { }

        public override async Task<RequestResult<List<CompanyDto>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var Companies =await  _repository.GetAll()
                .OrderBy(c => c.Name)
                .ProjectToType<CompanyDto>()
                .ToListAsync(cancellationToken);//.FirstOrDefaultAsync(cancellationToken);

            if (Companies ==null )
            return RequestResult<List<CompanyDto>>.Failure("No Companies found", ErrorCode.CompanyNotExist);

            return RequestResult<List<CompanyDto>>.Success(Companies);

        }

    }
}