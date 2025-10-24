namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Queries.GetCountryById.Dtos
{
    public class CountryDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }

    }
}
