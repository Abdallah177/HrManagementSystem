using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using MediatR;
using MediatR.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.Comman
{
    public record CheckExistQuery_Request(string Title) : IRequest<bool>;

    public class CheckExistQuery_RequestHandler : RequestHandlerBase<CheckExistQuery_Request, bool,Request>
    {
        public CheckExistQuery_RequestHandler(RequestHandlerBaseParameters<Request> parameters)
            : base(parameters)
        {
        }
        public override async Task<bool> Handle(CheckExistQuery_Request request, CancellationToken cancellationToken)
        {
            var exists = await _repository
                .Get(r => r.Title == request.Title)
                .AnyAsync(cancellationToken);
            return exists;
        }
    }
   
}
