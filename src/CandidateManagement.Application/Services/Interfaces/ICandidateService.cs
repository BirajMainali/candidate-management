using CandidateManagement.Application.Dtos;

namespace CandidateManagement.Application.Services.Interfaces;

public interface ICandidateService
{
    Task<(long? id, List<string> errors)> AddOrUpdateAsync(CandidateDto dto);
}