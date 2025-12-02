using FluentValidation;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.DTOS;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.RequestOrchestrator
{
    public class AddRequestViewModelWithScop
    {

        //list of List Ids {o,c,b,d,t}

        public OrganizationViewModel ScopeViewModel { get; set; } = null!;
        
        //Property
        
        public string Title { get; set; }
        public RequestStatus Status { get; set; }
        public  string Description { get; set; }
          

    }

    public class AddRequestViewModelValidator : AbstractValidator<AddRequestViewModelWithScop>
    {
        public AddRequestViewModelValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request data is required.");  
           
        }
    }

    public class PropertyAddRequestViewModel
    {
      
      

    }
}
