namespace HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetAllCities.Queries.Dtos
{
    public class CityResponseDto
    {
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
