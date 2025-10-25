using FluentValidation;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HrManagementSystem.Common
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseEndPoint<TRequest, TResult> : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IValidator<TRequest> _validator;
        protected readonly UserState _userState;
        public BaseEndPoint(EndpointBaseParameters<TRequest> parameters)
        {
            _mediator = parameters.Mediator;
            _validator = parameters.Validator;
            _userState = parameters.UserState;
        }

        protected EndpointResponse<TResult> ValidateRequest(TRequest request)
        {
            var validateResult = _validator.Validate(request);
            if (!validateResult.IsValid)
            {
                var errorMessage = string.Join(", ", validateResult.Errors.Select(e => e.ErrorMessage));
                return EndpointResponse<TResult>.Failure(errorMessage);
            }
            return EndpointResponse<TResult>.Success(default, "Validation successful");
        }

        protected Guid GetCurrentUserId()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                // Using JwtRegisteredClaimNames.Sub for user ID (GUID)
                var userIdClaim = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
                                ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userIdClaim) && Guid.TryParse(userIdClaim, out Guid userId))
                {
                    return userId;
                }
            }
            return Guid.Empty;
        }
    }
}
