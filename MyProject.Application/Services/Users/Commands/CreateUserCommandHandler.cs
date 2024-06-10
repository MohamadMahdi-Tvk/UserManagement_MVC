using AutoMapper;
using MediatR;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.UnitOfWork;
using MyProject.DataAccess.ViewModels.Roles.Queries.GetRoles;
using MyProject.DataAccess.ViewModels.Users.Commands.CreateUser;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUsers;

namespace MyProject.Application.Services.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _mapper.Map<CreateUserRequest, User>(request.Command);

            var roles = await _unitOfWork.RoleRepository.GetRoles();
 

            await _unitOfWork.UserRepository.Create(user, roles);

            var response = await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateUserResponse(IsSuccess: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
