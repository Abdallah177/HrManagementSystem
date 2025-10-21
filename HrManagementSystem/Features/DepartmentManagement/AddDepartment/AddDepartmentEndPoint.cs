using HrManagementSystem.Common;

namespace HrManagementSystem.Features.DepartmentManagement.AddDepartment
{
    public class AddDepartmentEndPoint : BaseEndPoint<AddDepartmentRequestViewModel, bool>
    {
        public AddDepartmentEndPoint(EndpointBaseParameters<AddDepartmentRequestViewModel> parameters) : base(parameters)
        {
        }
    }
}
