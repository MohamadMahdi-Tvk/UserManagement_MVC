using MyProject.DataAccess.Entities;

namespace MyProject.DataAccess.ViewModels.Users.Commands.CreateUser;

public record CreateUserRequest(string FirstName, string LastName, List<Role> Roles);
