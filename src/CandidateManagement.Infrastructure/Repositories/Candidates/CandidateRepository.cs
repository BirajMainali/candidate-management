using CandidateManagement.Domain.Entities;
using CandidateManagement.Infrastructure.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement.Infrastructure.Repositories.Candidates;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    private readonly DbContext _dbContext;

    public CandidateRepository(DbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Candidate?> FindByEmailAsync(string email) =>
        _dbContext.Set<Candidate>().FirstOrDefaultAsync(x => x.Email == email);
}