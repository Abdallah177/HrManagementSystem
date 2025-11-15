using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.FeatureSope;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HrManagementSystem.Features.DisabilityManagement.Common.CheckIsEntityExist.Queries
{
    public record CheckIsEntityExistQuery<TConfiguration>(Expression<Func<TConfiguration, bool>> Predicate) : IRequest<bool >where TConfiguration : BaseModel;
    public class CheckIsEntityExistQueryHandler<TConfiguration> : RequestHandlerBase<CheckIsEntityExistQuery<TConfiguration>, bool, TConfiguration> where TConfiguration : BaseModel
    {
        public CheckIsEntityExistQueryHandler(RequestHandlerBaseParameters<TConfiguration> parameters) : base(parameters)
        {
        }

        public async override Task<bool> Handle(CheckIsEntityExistQuery<TConfiguration> request, CancellationToken cancellationToken)
        {
            var exists = await _repository.IsExistsAsync(request.Predicate);
            return exists;
        }
    }
}
