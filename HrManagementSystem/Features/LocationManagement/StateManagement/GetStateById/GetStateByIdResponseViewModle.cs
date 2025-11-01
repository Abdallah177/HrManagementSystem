using HrManagementSystem.Features.LocationManagement.StateManagement.GetStateById.Queries.Dto;

namespace HrManagementSystem.Features.LocationManagement.StateMangement.GetStateById
{
    public class GetStateByIdResponseViewModle
    {
        public string Id { get; set; } 
        public string Name { get; set; } 
        public GetCountryViewModle Country { get; set; }
        public List<GetCityViewModle> Cities { get; set; }
    }

    public class GetCountryViewModle
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class GetCityViewModle
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }

}
