namespace HrManagementSystem.Features.OverTimeManagement.GetAll;

public record GetAllOverTimeDto(decimal RatePerHour, int MaxHoursPerMonth, bool RequiresApproval);
