using AutoMapper;
using MediatR;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.UnitOfWork;
using MyProject.DataAccess.ViewModels.Users.Commands.DeleteUser;

namespace MyProject.Application.Services.Users.Commands;

public record DeleteUserCommand(DeleteUserRequest Command, CancellationToken CancellationToken) : IRequest<DeleteUserResponse>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var deleteUserMapped = _mapper.Map<DeleteUserRequest, User>(request.Command);

            await _unitOfWork.UserRepository.DeleteUser(deleteUserMapped.Id);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new DeleteUserResponse(IsSuccess: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

