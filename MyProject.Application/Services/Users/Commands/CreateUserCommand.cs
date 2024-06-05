using MediatR;
using MyProject.DataAccess.ViewModels.Users.Commands.CreateUser;

namespace MyProject.Application.Services.Users.Commands;

public record CreateUserCommand(CreateUserRequest Command, CancellationToken CancellationToken): IRequest<CreateUserResponse>;
