using FluentValidation;
using MediatR;

namespace HrManagementSystem.Common
{
    public class EndpointBaseParameters<TRequest>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TRequest> _validator;

        public IMediator Mediator => _mediator;
        public IValidator<TRequest> Validator => _validator;



        public EndpointBaseParameters(IMediator mediator, IValidator<TRequest> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }
    }
}
