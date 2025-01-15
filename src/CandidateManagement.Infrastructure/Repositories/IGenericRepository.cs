using CandidateManagement.Domain.Entities;

namespace CandidateManagement.Infrastructure.Repositories;

public interface IGenericRepository<T> where T : class, IEntity
{
    Task<T> AddAsync(T t);
    void Update(T t);
    
    Task SaveChangesAsync();
}