using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.GetAllCompany.Query;
using HrManagementSystem.Features.OnBoardingManagement.GenerateScope.Dtos;
using HrManagementSystem.Features.OnBoardingManagement.Queries;
using Mapster;
using MediatR;
using System.Net.NetworkInformation;

namespace HrManagementSystem.Features.OnBoardingManagement.GenerateScope.Commands
{
    public record GenerateScopeCommand(List<GenerateScopesDto> scopesData, string currentUserId) : IRequest<RequestResult<int>>;

    public class GenerateScopeCommandHandler : RequestHandlerBase<GenerateScopeCommand, RequestResult<int>, ScopeBase>
    {
        public GenerateScopeCommandHandler(RequestHandlerBaseParameters<ScopeBase> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<int>> Handle(GenerateScopeCommand request, CancellationToken cancellationToken)
        {
            var scopes = request.scopesData.Adapt<List<ScopeBase>>();

            await _repository.AddRangeAsync(scopes, request.currentUserId, cancellationToken);

            return RequestResult<int>.Success(scopes.Count, $"Generated {scopes.Count} scopes successfully");

        }
    }

}
