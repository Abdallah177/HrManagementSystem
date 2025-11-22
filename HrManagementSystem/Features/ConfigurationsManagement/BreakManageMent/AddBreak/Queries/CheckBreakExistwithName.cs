using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Queries
{
    public record CheckBreakExistwithName (string Name) : IRequest<bool>;

    public class CheckBreakExistwithNameHandler : RequestHandlerBase<CheckBreakExistwithName, bool, Break>
    {
        public CheckBreakExistwithNameHandler(RequestHandlerBaseParameters<Break> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckBreakExistwithName request, CancellationToken cancellationToken)
        {
            var result =await _repository.Get(b => b.Name == request.Name).AnyAsync(cancellationToken);

            return result;
        }
    }

}
