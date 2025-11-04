using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using MediatR;
using Mapster;
using HrManagementSystem.Features.CompanyManagement.GetCompanyById.Dtos;

namespace HrManagementSystem.Features.CompanyManagement.GetCompanyById.Queries
{
    public record GetCompanyByIdQuery(string companyId) : IRequest<RequestResult<CompanyDto>>;

    public class GetCompanyByIdQueryHandler
        : RequestHandlerBase<GetCompanyByIdQuery, RequestResult<CompanyDto>, Company>
    {
        public GetCompanyByIdQueryHandler(RequestHandlerBaseParameters<Company> parameters)
            : base(parameters)
        {
        }

        public override async Task<RequestResult<CompanyDto>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIDAsync(request.companyId, cancellationToken);

            if (company == null)
                return RequestResult<CompanyDto>.Failure(
                    "Company does not exist.",
                    ErrorCode.CompanyNotExist
                );

            var companyDto = company.Adapt<CompanyDto>();

            return RequestResult<CompanyDto>.Success(companyDto);
        }
    }


}
