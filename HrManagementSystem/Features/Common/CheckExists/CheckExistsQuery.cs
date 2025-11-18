using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using MediatR;
using System.Linq.Expressions;

namespace HrManagementSystem.Features.Common.CheckExists
{
    public record CheckExistsQuery<TEntity> : IRequest<bool> where TEntity : BaseModel
    {
        public string? Id { get; init; }
        public Expression<Func<TEntity, bool>>? Predicate { get; init; }

        // Constructor 1: Check by ID
        public CheckExistsQuery(string id)
        {
            Id = id;
            Predicate = null;
        }

        // Constructor 2: Check by Predicate
        public CheckExistsQuery(Expression<Func<TEntity, bool>> predicate)
        {
            Id = null;
            Predicate = predicate;
        }

    }

    public class CheckExistsQueryHandler<TEntity>: RequestHandlerBase<CheckExistsQuery<TEntity>, bool, TEntity> where TEntity : BaseModel
    {
        public CheckExistsQueryHandler(RequestHandlerBaseParameters<TEntity> parameters)
            : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckExistsQuery<TEntity> request,CancellationToken cancellationToken)
        {
            // Build predicate based on what's provided
            Expression<Func<TEntity, bool>> predicate;

            if (!string.IsNullOrEmpty(request.Id))
                predicate = x => x.Id == request.Id;

            else
                predicate = request.Predicate!;
            
            var exists = await _repository.IsExistsAsync(predicate , cancellationToken);
            return exists;
        }
    }
}


