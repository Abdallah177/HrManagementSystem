using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.DeleteCompany.Commands;
using MediatR;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;
using HrManagementSystem.Features.CompanyManagement.AddCompany.Dtos;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using HrManagementSystem.Features.OnBoardingManagement.Commands.GenerateScope;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingOrchestrator(OnBoardingDto OnBoardingDto, string currentUserId) : IRequest<RequestResult<bool>>;

    public class OnBoardingOrchestratorHandler : RequestHandlerBase<OnBoardingOrchestrator, RequestResult<bool>, Organization>
    {
        public OnBoardingOrchestratorHandler(RequestHandlerBaseParameters<Organization> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(OnBoardingOrchestrator request, CancellationToken cancellationToken)
        {
            var organizationResult = await _mediator.Send(new OnBoardingOrgainzationCommand(request.OnBoardingDto.Organization.Name, request.currentUserId), cancellationToken);
            var companiesDto = request.OnBoardingDto.Organization.Companies
                .Select(c => new CompaniesDto(
                    c.Name,
                    c.Email,
                    c.CountryId,
                    organizationResult.Data,
                    c.Branches
                )).ToList();

            var companiesResult = await _mediator.Send(new OnBoardingCompainesCommand(companiesDto, request.currentUserId),cancellationToken);

                var branchesDto = companiesResult.Data
                   .SelectMany(company =>
                    company.Branches.Any() ? company.Branches.Select(branch => 
                    new BranchesDto(
                            branch.Name,
                            branch.Phone,
                            branch.CityId,
                            company.CompanyId,
                            branch.Departments
                          ))
                        : new[] 
                        { 
                            new BranchesDto
                            (
                                $"{company.CompanyName} Branch",
                                null,
                                company.DefaultCity,  
                                company.CompanyId,
                                new List<DepartmentsDto>()

                            )}).ToList();


            var branchesResult = await _mediator.Send(new OnBoardingBranchesCommand(branchesDto, request.currentUserId),cancellationToken);

            var departmentsDto = branchesResult.Data
                  .SelectMany(branch =>
                    branch.Departments.Any() ? branch.Departments.Select(dept => 

                    new DepartmentsDto(
                    dept.Name,
                    dept.Description,
                    branch.BranchId,
                    dept.Teams)) 
                  : new[] 
                  { 
                  new DepartmentsDto
                  (
                     $"{branch.BranchName} Department",
                     "Default department",
                      branch.BranchId,
                      new List<TeamsDto>()
                  )}).ToList();

            var departmentsResult = await _mediator.Send(new OnBoardingDepartmentsCommand(departmentsDto, request.currentUserId),cancellationToken);

            var teamsDto = departmentsResult.Data
             .SelectMany(dept => dept.Teams.Any() ? dept.Teams
             .Select(team => 
             new TeamsDto(
                 team.Name,
                 dept.DepartmentId
               ))
              : new[]
              {
                 new TeamsDto(
                 $"{dept.DepartmentName} Team",
                    dept.DepartmentId)
               }).ToList();

            var teamsResult = await _mediator.Send(new OnBoardingTeamsCommand(teamsDto, request.currentUserId),cancellationToken);

            if (!teamsResult.IsSuccess)
                return RequestResult<bool>.Failure(teamsResult.Message, teamsResult.ErrorCode);

            //generate scops
            var generateScops = await _mediator.Send(new GenerateScopeCommand(organizationResult.Data,request.currentUserId));

            if (!generateScops.IsSuccess)
                return RequestResult<bool>.Failure(generateScops.Message, generateScops.ErrorCode);

            return RequestResult<bool>.Success(true,$"Organization onboarded successfully and created the scops correctly : {generateScops.Data} scops!");

        }
    }
}
