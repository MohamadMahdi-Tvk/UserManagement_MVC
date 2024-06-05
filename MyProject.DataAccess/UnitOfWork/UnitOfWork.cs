using MyProject.DataAccess.Context;
using MyProject.DataAccess.Repositories.UserRepository;

namespace MyProject.DataAccess.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task<int> CommitAsync(CancellationToken cancellationToken);
}

public class UnitOfWork : IUnitOfWork
{
    private readonly IUserRepository _userRepository;
    private readonly DataBaseContext _context;
    public UnitOfWork(IUserRepository userRepository, DataBaseContext context)
    {
        _userRepository = userRepository;
        _context = context;
    }

    public IUserRepository UserRepository => _userRepository;



    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
