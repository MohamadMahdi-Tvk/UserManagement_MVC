using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Context;
using MyProject.DataAccess.Entities;

namespace MyProject.DataAccess.Repositories.RoleRepository;

public interface IRoleRepository
{
    Task<List<Role>> GetRoles();
}

public class RoleRepository : IRoleRepository
{
    private readonly DataBaseContext _context;
    public RoleRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetRoles()
    {
        return await _context.Roles.ToListAsync();
    }
}
