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
            var branchesDto = new List<BranchesDto>();
            var departmentsDto = new List<DepartmentsDto>();

            var organizationResult = await _mediator.Send(new OnBoardingOrgainzationCommand(request.OnBoardingDto.Organization.Name, request.currentUserId), cancellationToken);
            var companiesDto = request.OnBoardingDto.Organization.Compaines
                .Select(c => new CompaniesDto(
                    c.Name,
                    c.Email,
                    c.CountryId,
                    organizationResult.Data,
                    c.Branches
                )).ToList();

            var companiesResult = await _mediator.Send(new OnBoardingCompainesCommand(companiesDto, request.currentUserId),cancellationToken);

            foreach (var company in companiesResult.Data)
            {
                if (company.Branches.Count() > 0)
                {
                    foreach (var branch in company.Branches)
                    {
                        branchesDto.Add(new BranchesDto(
                            branch.Name,
                            branch.Phone,
                            branch.CityId,
                            company.CompanyId,
                            branch.Departments
                        ));
                    }
                }
                else
                {
                        branchesDto.Add(new BranchesDto(
                            $"{company.CompanyId} Branch", 
                            null,
                            null,  // You may need to provide default CityId
                            company.CompanyId,
                            new List<DepartmentsDto>()
                        ));
                    
                }
            }

            var branchesResult = await _mediator.Send(new OnBoardingBranchesCommand(branchesDto, request.currentUserId),cancellationToken);

            foreach (var branch in branchesResult.Data)
            {
                if (!branch.Departments.Any())
                {
                    foreach (var dept in branch.Departments)
                    {
                        departmentsDto.Add(new DepartmentsDto(
                            dept.Name,
                            dept.Description,
                            branch.BranchId,
                            dept.Teams
                        ));
                    }
                }
                else
                {

                }
            }

            var departmentsResult = await _mediator.Send(new OnBoardingDepartmentsCommand(departmentsDto, request.currentUserId),cancellationToken);

            if (!departmentsResult.IsSuccess)
                return RequestResult<bool>.Failure(departmentsResult.Message, departmentsResult.ErrorCode);

            var teamsDto = new List<TeamsDto>();
            foreach (var dept in departmentsResult.Data)
            {
                foreach (var team in dept.Teams)
                {
                    teamsDto.Add(new TeamsDto(
                        team.Name,
                        dept.DepartmentId 
                    ));
                }
            }

            var teamsResult = await _mediator.Send(new OnBoardingTeamsCommand(teamsDto, request.currentUserId),cancellationToken);

            if (!teamsResult.IsSuccess)
                return RequestResult<bool>.Failure(teamsResult.Message, teamsResult.ErrorCode);

            return RequestResult<bool>.Success(true,$"Organization onboarded successfully!");

        }
    }
}
