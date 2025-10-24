using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.CompanyManagement.GetCompanyById.Queries;

public record GetCompanyByIdQuery(string Id) : IRequest<EndpointResponse<GetCompanyByIdDto>>;

public class GetCompanyByIdQueryHandler(IGenericRepository<Company> genericRepository) : IRequestHandler<GetCompanyByIdQuery, EndpointResponse<GetCompanyByIdDto>>
{
    private readonly IGenericRepository<Company> _genericRepository = genericRepository;

    public async Task<EndpointResponse<GetCompanyByIdDto>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _genericRepository.Get(x => x.Id == request.Id).Select(x => new GetCompanyByIdDto(x.Id, x.Name, x.Country.Name, x.Organization.Name))
            .FirstOrDefaultAsync(cancellationToken);

        if (company is null)
            return EndpointResponse<GetCompanyByIdDto>.Failure("Company not found");

        return EndpointResponse<GetCompanyByIdDto>.Success(company);
    }
}
