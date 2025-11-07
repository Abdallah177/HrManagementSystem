using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands.GenerateScope
{
    public record GenerateScopeCommand(): IRequest<RequestResult<bool>>;

}
