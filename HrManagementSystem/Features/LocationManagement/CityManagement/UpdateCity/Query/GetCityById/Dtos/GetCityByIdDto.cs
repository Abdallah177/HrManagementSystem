namespace HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity.Query.GetCityById.Dtos
{
    public class GetCityByIdDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string StateId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public string CreatedByUser { get; set; }


    }
}
