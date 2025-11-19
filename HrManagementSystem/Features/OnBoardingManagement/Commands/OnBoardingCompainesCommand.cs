using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries.Dtos;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;
using HrManagementSystem.Features.OnBoardingManagement.Queries.GetDefaultCitiesByCountryIds;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingCompainesCommand(List<CompaniesDto> companies, string OrganizationId, string currentUserId) : IRequest<RequestResult<List<CompaniesResponseDto>>>;

    public class OnBoardingCompainesCommandHandler : RequestHandlerBase<OnBoardingCompainesCommand, RequestResult<List<CompaniesResponseDto>>, Company>
    {
        public OnBoardingCompainesCommandHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }
        public override async Task<RequestResult<List<CompaniesResponseDto>>> Handle(OnBoardingCompainesCommand request, CancellationToken cancellationToken)
        {
            var companies = request.companies.Adapt<List<Company>>();
            companies.ForEach(c => c.OrganizationId = request.OrganizationId);

            await _repository.AddRangeAsync(companies, request.currentUserId, cancellationToken);

            //get defaultCityId if branches not exist
            var countryIds = request.companies.Where(c => c.Branches == null || !c.Branches.Any()).Select(c => c.CountryId).Distinct().ToList();
            var defaultCities = countryIds.Any() ?
                (await _mediator.Send(new GetDefaultCitiesByCountryIdsQuery(countryIds), cancellationToken))?.Data ?? new Dictionary<string, string>() : new Dictionary<string, string>();

            var companiesResponses = companies.Select((company, index) => new CompaniesResponseDto
            {
                CompanyId = company.Id,
                CompanyName = company.Name,
                DefaultCityId = request.companies[index].Branches?.Any() == true ? null : defaultCities.GetValueOrDefault(request.companies[index].CountryId),
                Branches = request.companies[index].Branches 

            }).ToList();

            return RequestResult<List<CompaniesResponseDto>>.Success(companiesResponses, "Companies created successfully");
        }
    }
}