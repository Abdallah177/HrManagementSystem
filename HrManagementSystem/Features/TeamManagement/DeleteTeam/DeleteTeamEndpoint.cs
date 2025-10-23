using HrManagementSystem.Common;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam
{
    public class DeleteTeamEndpoint : BaseEndPoint<object, GetAllOrganizationResponseViewModel>
    {
        public DeleteTeamEndpoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }
        [HttpDelete]
    }
}
