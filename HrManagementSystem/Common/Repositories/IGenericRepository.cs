using HrManagementSystem.Common.Entities;
using System.Linq.Expressions;

namespace HrManagementSystem.Common.Repositories
{
    public interface IGenericRepository<Entity> where Entity : BaseModel
    {
        // --------------------- Get ---------------------
        IQueryable<Entity> GetAll();
        IQueryable<Entity> Get(Expression<Func<Entity, bool>> expression);
        Task<Entity?> GetByIDAsync(string id, CancellationToken cancellationToken = default);

        // --------------------- Add ---------------------
        Task AddAsync(Entity entity, CancellationToken cancellationToken);
        Task AddAsync(Entity entity, string currentUserId, CancellationToken cancellationToken);

        // --------------------- Update ---------------------
        void Update(Entity entity);

        void Update(Entity entity, string currentUserId);

        // --------------------- Delete ---------------------
        Task DeleteAsync(string id, string currentUserId, CancellationToken cancellationToken);
    }
}
