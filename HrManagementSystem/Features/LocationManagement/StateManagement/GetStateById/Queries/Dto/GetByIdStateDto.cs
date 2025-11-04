namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetStateById.Queries.Dto
{
    public class GetByIdStateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public GetCountryDto Country { get; set; }
        public List<GetCityDto> Cities { get; set; } 

    }

    public class GetCountryDto
    {
        public  string Id { get; set; } 
        public string Name { get; set; } 
    }

    public class GetCityDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}