using Microsoft.EntityFrameworkCore;

namespace Danilvar.UnitOfWork;

public class UnitOfWork<T> where T : DbContext
{
    private readonly T _context;

    public UnitOfWork(T context)
    {
        _context = context;
    }

    public async Task<bool> CompleteAsync() =>
        await _context.SaveChangesAsync() > 0;

    public bool HasChanges() =>
        _context.ChangeTracker.HasChanges();
}