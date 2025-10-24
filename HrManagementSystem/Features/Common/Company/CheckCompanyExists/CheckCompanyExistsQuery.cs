using HrManagementSystem.Common;
using MediatR;

namespace HrManagementSystem.Features.Common.Company.CheckCompanyExists
{
    public record CheckCompanyExistsQuery(string Id) : IRequest<bool>;

    public class CheckCompanyExistsQueryHandler : RequestHandlerBase<CheckCompanyExistsQuery, bool, HrManagementSystem.Common.Entities.Company>
    {
        public CheckCompanyExistsQueryHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Company> parameters) : base(parameters)
        {
        }

        public override async Task<bool> Handle(CheckCompanyExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.IsExistsAsync(C => C.Id == request.Id);

            if (result)
                return false;
            return true;
        }
    }


}
