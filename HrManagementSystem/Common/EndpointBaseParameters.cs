using FluentValidation;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Common
{
    public class EndpointBaseParameters<TRequest>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TRequest> _validator;
        private readonly UserState _userState;

        public IMediator Mediator => _mediator;
        public IValidator<TRequest> Validator => _validator;
        public UserState UserState => _userState;   



        public EndpointBaseParameters(IMediator mediator, IValidator<TRequest> validator ,UserState userState)
        {
            _mediator = mediator;
            _validator = validator;
            _userState = userState;
        }

        public EndpointBaseParameters(IMediator mediator)
        {
            _mediator = mediator;
            _validator = null!;
            _userState = null!;
        }
    }
}
