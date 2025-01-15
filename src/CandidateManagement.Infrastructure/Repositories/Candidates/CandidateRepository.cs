using CandidateManagement.Domain.Entities;
using CandidateManagement.Infrastructure.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement.Infrastructure.Repositories.Candidates;

public class CandidateRepository(CandidateManagementDbContext dbContext)
    : GenericRepository<Candidate>(dbContext), ICandidateRepository
{
    public Task<Candidate?> FindByEmailAsync(string email) => dbContext.Candidates.FirstOrDefaultAsync(x => x.Email == email);
}