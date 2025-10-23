namespace HrManagementSystem.Features.LocationManagement.CityManagement.GetByIDCity
{
    public class GetCityByIdResponseViewModel
    {
        public string CityName { get; set; }

        public string? StateName { get; set; }
        public string? CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
