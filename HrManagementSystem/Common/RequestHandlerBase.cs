using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using MediatR;

namespace HrManagementSystem.Common
{
    public abstract class RequestHandlerBase<TRequest, TResponse, TEntity>
    : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TEntity : BaseModel
    { 
        protected readonly IMediator _mediator;

        protected readonly IGenericRepository<TEntity> _repository;

        public RequestHandlerBase(RequestHandlerBaseParameters<TEntity> parameters)
        {
            _mediator = parameters.Mediator;
            _repository = parameters.Repository;
        }


        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
