using HrManagementSystem.Common.Data;

namespace HrManagementSystem.Common.Middlewares
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly AppDbContext _context;
        public TransactionMiddleware(AppDbContext context)
        {
            _context = context;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //for get endpoints
            if (context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
            {
                // Skip transaction for GET requests
                await next(context);
                return;
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await next(context);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
