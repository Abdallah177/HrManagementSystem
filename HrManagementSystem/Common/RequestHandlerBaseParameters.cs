using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using MediatR;

namespace HrManagementSystem.Common
{
    public class RequestHandlerBaseParameters<TEntity> where TEntity : BaseModel
    {
        public IMediator Mediator => _mediator;
        public IGenericRepository<TEntity> Repository => _repository;

        private readonly IMediator _mediator;
        private readonly IGenericRepository<TEntity> _repository;

        public RequestHandlerBaseParameters(IMediator mediator, IGenericRepository<TEntity> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
    }
}
