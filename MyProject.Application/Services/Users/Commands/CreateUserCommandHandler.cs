using AutoMapper;
using MediatR;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.Repositories.UserRepository;
using MyProject.DataAccess.UnitOfWork;
using MyProject.DataAccess.ViewModels.Users.Commands.CreateUser;

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

            await _unitOfWork.UserRepository.Create(user);

            var response = await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateUserResponse(IsSuccess: true);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
