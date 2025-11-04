namespace HrManagementSystem.Features.OverTimeManagement.GetAll;

public record GetAllOverTimeViewModel(decimal RatePerHour, int MaxHoursPerMonth, bool RequiresApproval);