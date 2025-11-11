namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetBreakById.Dtos
{
    public record GetBreakByIdDto (string Id,string Name , TimeSpan Duration , bool IsPaid);
    
}
