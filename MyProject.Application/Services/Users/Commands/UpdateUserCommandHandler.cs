using AutoMapper;
using MediatR;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.UnitOfWork;
using MyProject.DataAccess.ViewModels.Users.Commands.UpdateUser;

namespace MyProject.Application.Services.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userMapped = _mapper.Map<UpdateUserRequest, User>(request.Command);

            await _unitOfWork.UserRepository.UpdateUser(userMapped);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateUserResponse(userMapped.Id, IsSuccess: true);
        }

        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
