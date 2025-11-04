using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingCompainesCommand(List<CompaniesDto> companies, string currentuserId) : IRequest<RequestResult<List<CompaniesResponseDto>>>;

    public class OnBoardingCompainesCommandHandler : RequestHandlerBase<OnBoardingCompainesCommand, RequestResult<List<CompaniesResponseDto>>, Company>
    {
        public OnBoardingCompainesCommandHandler(RequestHandlerBaseParameters<Company> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<CompaniesResponseDto>>> Handle(OnBoardingCompainesCommand request, CancellationToken cancellationToken)
        {
            List<CompaniesResponseDto> companiesResponses = new();
            foreach (var companyDto in request.companies)
            {
                var company = companyDto.Adapt<Company>();
                await _repository.AddAsync(company, cancellationToken);
                companiesResponses.Add(new CompaniesResponseDto
                {
                    companyId = company.Id,
                    branches = companyDto.Branches,
                });
            }

             return RequestResult<List<CompaniesResponseDto>>.Success(companiesResponses , "companies created succesfully");
        }
    }
}
