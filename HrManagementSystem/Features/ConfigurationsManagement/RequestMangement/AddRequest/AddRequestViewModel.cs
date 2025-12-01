using FluentValidation;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator;
using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.DTOS;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest
{
    public class AddRequestViewModel
    {
       

        //list of List Ids {o,c,b,d,t}
        public ScopeViewModel ScopeViewModel { get; set; } = null!;

        //entity id 
        public string ConfigId { get; set; } = null!;

        //Property
        
        public AddRequestCommand AddRequestCommand { get; set; }


    }

    public class AddRequestViewModelValidator : AbstractValidator<AddRequestViewModel>
    {
        public AddRequestViewModelValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request data is required.");
            RuleFor(x => x.ConfigId).NotEmpty().WithMessage("ConfigId is required.");   
           
        }
    }

    public class PropertyAddRequestViewModel
    {
      
      

    }
}
