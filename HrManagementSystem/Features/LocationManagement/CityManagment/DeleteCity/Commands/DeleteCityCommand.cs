using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.LocationManagement.CityManagment.DeleteCity.Commands
{
    public record DeleteCityCommand(string Id):IRequest<RequestResult<bool>>;

    public class DeleteCityCommandHandler:RequestHandlerBase<DeleteCityCommand, RequestResult<bool>,State>
    {
        public DeleteCityCommandHandler(RequestHandlerBaseParameters<State> parameters) : base(parameters) { }
        public override Task<RequestResult<bool>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    
}
