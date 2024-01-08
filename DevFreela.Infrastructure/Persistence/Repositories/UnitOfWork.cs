using Microsoft.EntityFrameworkCore.Storage;

using DevFreela.Domain.Repositories;
using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public IProjectRepository Projects { get; }
    public IUserRepository Users { get; }
    public ISkillRepository Skills { get; }

    private readonly DevFreelaDbContext _dbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(
        DevFreelaDbContext dbContext,
        IProjectRepository projects,
        IUserRepository users,
        ISkillRepository skills)
    {
        _dbContext = dbContext;
        Projects = projects;
        Users = users;
        Skills = skills;
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            _dbContext.Dispose();
    }
}