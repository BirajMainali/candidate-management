using CandidateManagement.Domain.Entities;
using CandidateManagement.Infrastructure.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement.Infrastructure.Repositories;

public class GenericRepository<T> where T : class, IEntity
{
    private readonly DbContext _dbContext;
    protected GenericRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T> AddAsync(T t)
    {
        await _dbContext.Set<T>().AddAsync(t);
        return t;
    }
    public void Update(T t) => _dbContext.Update(t);
    
    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}