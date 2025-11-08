using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.GetAllCompany.Query;
using HrManagementSystem.Features.OnBoardingManagement.Queries;
using Mapster;
using MediatR;
using System.Net.NetworkInformation;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.GenerateScope
{
    public record GenerateScopeCommand(string OrganizationId ,string currentUserId) : IRequest<RequestResult<int>>;

    public class GenerateScopeCommandHandler : RequestHandlerBase<GenerateScopeCommand, RequestResult<int>, ScopeBase>
    {
        public GenerateScopeCommandHandler(RequestHandlerBaseParameters<ScopeBase> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<int>> Handle(GenerateScopeCommand request, CancellationToken cancellationToken)
        {
            var scopeGenerated = await _mediator.Send(new GetAllScopesQuery(request.OrganizationId));
            var scopes = scopeGenerated.Adapt<List<ScopeBase>>();

            await _repository.AddRangeAsync(scopes, request.currentUserId, cancellationToken);

            return RequestResult<int>.Success(scopes.Count,$"Generated {scopes.Count} scopes successfully");

        }
    }

}
