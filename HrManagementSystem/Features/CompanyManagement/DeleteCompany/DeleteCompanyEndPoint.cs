using HrManagementSystem.Common;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany
{
    public class DeleteCompanyEndPoint : BaseEndPoint<DeleteCompanyRequestViewModel, bool>
    {
        public DeleteCompanyEndPoint(EndpointBaseParameters<DeleteCompanyRequestViewModel> parameters) : base(parameters)
        {
        }
    }
}
