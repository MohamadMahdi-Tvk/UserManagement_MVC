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

    public async Task Create(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}
