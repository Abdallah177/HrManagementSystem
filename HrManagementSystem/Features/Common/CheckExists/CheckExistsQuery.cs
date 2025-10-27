using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using MediatR;

namespace HrManagementSystem.Features.Common.CheckExists
{
    public record CheckExistsQuery<TEntity>(string Id) : IRequest<bool> where TEntity : BaseModel;

    public class CheckExistsQueryHandler<TEntity>
    : RequestHandlerBase<CheckExistsQuery<TEntity>, bool, TEntity>
    where TEntity : BaseModel
    {
        public CheckExistsQueryHandler(RequestHandlerBaseParameters<TEntity> parameters)
            : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckExistsQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var exists = await _repository.IsExistsAsync(x => x.Id == request.Id);
            return exists;
        }
    }


}
