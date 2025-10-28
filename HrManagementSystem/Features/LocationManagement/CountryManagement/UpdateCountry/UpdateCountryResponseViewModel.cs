namespace HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry
{
    public class UpdateCountryResponseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public string UpdatedByUser { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}