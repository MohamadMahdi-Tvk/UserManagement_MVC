using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUser;

namespace MyProject.DataAccess.Repositories.UserRepository;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task Create(User user);
    Task<User> GetUserById(int id);
    Task UpdateUser(User updateUser);

    Task DeleteUser(int id);
}

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _context;

    public UserRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }


    public async Task Create(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task UpdateUser(User updateUser)
    {
        var userFind = await _context.Users.FindAsync(updateUser.Id);

        userFind.FirstName = updateUser.FirstName;
        userFind.LastName = updateUser.LastName;

    }

    public async Task DeleteUser(int id)
    {
        _context.Users.Remove(new User { Id = id });
    }
}
