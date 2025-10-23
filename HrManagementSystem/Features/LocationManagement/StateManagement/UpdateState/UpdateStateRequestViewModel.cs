namespace HrManagementSystem.Features.LocationManagement.StateManagement.UpdateState
{
    public class UpdateStateRequestViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;

        public string CountryId { get; set; } = null!;
    }
}
