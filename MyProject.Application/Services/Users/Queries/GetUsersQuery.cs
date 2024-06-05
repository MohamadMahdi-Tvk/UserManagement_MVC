using MediatR;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUsers;

namespace MyProject.Application.Services.Users.Queries;

public record GetUsersQuery(CancellationToken CancellationToken) : IRequest<IEnumerable<GetUsersResponse>>;

