using MediatR;
using MyProject.DataAccess.ViewModels.Users.Commands.UpdateUser;

namespace MyProject.Application.Services.Users.Commands;

public record UpdateUserCommand(UpdateUserRequest Command, CancellationToken CancellationToken) : IRequest<UpdateUserResponse>;
