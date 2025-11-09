using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries.Dtos;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;
using HrManagementSystem.Features.OnBoardingManagement.Queries.GetDefaultCitiesByCountryIds;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingCompainesCommand(List<CompaniesDto> companies , string OrganizationId, string currentUserId) : IRequest<RequestResult<List<CompaniesResponseDto>>>;

    public class OnBoardingCompainesCommandHandler : RequestHandlerBase<OnBoardingCompainesCommand, RequestResult<List<CompaniesResponseDto>>, Company>
    {
        public OnBoardingCompainesCommandHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }
            public override async Task<RequestResult<List<CompaniesResponseDto>>> Handle(OnBoardingCompainesCommand request,CancellationToken cancellationToken)
            {
               var companiesResponses = new List<CompaniesResponseDto>();
               var companiesDto = request.companies
                    .Select(c => new CompaniesDto
                    (
                        c.Name,
                        c.Email,
                        c.CountryId,
                        request.OrganizationId,
                        c.Branches
                    )).ToList();

               //for choose the first city as default value in branch
                var countryIds = companiesDto.Select(c => c.CountryId).Distinct().ToList();
                var defaultCities = await _mediator.Send(new GetDefaultCitiesByCountryIdsQuery(countryIds));

               foreach (var companyDto in companiesDto)
                {
                    var company = companyDto.Adapt<Company>();
                    await _repository.AddAsync(company, request.currentUserId, cancellationToken);

                    companiesResponses.Add(new CompaniesResponseDto
                    {
                      CompanyId = company.Id,
                      CompanyName = company.Name,
                      DefaultCityId = defaultCities.Data.GetValueOrDefault(companyDto.CountryId),
                      Branches = companyDto.Branches 
                    });
                }

                return RequestResult<List<CompaniesResponseDto>>.Success(companiesResponses,"Companies created successfully");
            }
        }
    }