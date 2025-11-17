using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.AddBranch.DTOS;
using HrManagementSystem.Features.Common.CheckExists;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.BranchManagement.AddBranch.Commands
{
    public record AddBranchCommand(string Name, string CityId, string? Phone, string CompanyId, string UserId) : IRequest<RequestResult<AddBranchDTO>>;

    public class AddBranchCommandHandler : RequestHandlerBase<AddBranchCommand, RequestResult<AddBranchDTO>, Branch>
    {
        public AddBranchCommandHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }
        public override async Task<RequestResult<AddBranchDTO>> Handle(AddBranchCommand request, CancellationToken cancellationToken)
        {
            // CheckCityExists
            var IsCityExists = await _mediator.Send(new CheckExistsQuery<City>(request.CityId));

            if (!IsCityExists)
                return RequestResult<AddBranchDTO>.Failure("City Not Found", ErrorCode.CityNotExist);

            // CheckCompanyExists
            var IsCompanyExists = await _mediator.Send(new CheckExistsQuery<Company>(request.CompanyId));

            if (!IsCompanyExists)
                return RequestResult<AddBranchDTO>.Failure("Company Not Found", ErrorCode.CompanyNotExist);

            var branch = request.Adapt<Branch>();
            await _repository.AddAsync(branch, request.UserId, cancellationToken);
            var branchDto = branch.Adapt<AddBranchDTO>();
            return RequestResult<AddBranchDTO>.Success(branchDto);
        }
    }


}
