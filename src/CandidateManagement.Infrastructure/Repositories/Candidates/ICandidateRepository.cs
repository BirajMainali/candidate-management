using CandidateManagement.Domain.Entities;

namespace CandidateManagement.Infrastructure.Repositories.Candidates;

public interface ICandidateRepository : IGenericRepository<Candidate>
{
    Task<Candidate?> FindByEmailAsync(string email);
}