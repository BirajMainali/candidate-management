using CandidateManagement.Application.Dtos;
using CandidateManagement.Application.Services.Interfaces;
using CandidateManagement.Domain.Entities;
using CandidateManagement.Infrastructure.Repositories.Candidates;

namespace CandidateManagement.Application.Services;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _candidateRepository;

    public CandidateService(ICandidateRepository candidateRepository)
    {
        _candidateRepository = candidateRepository;
    }

    public async Task<(long? id, List<string> errors)> AddOrUpdateAsync(CandidateDto dto)
    {
        var errors = EnsureRequiredField(dto);
        if (errors.Any()) return (null, errors);
        var candidate = await _candidateRepository.FindByEmailAsync(dto.Email);
        return candidate is not null ? (await UpdateAsync(candidate, dto), errors) : (await AddAsync(dto), errors);
    }

    private async Task<long> UpdateAsync(Candidate candidate, CandidateDto dto)
    {
        candidate.Update(dto.FirstName, dto.LastName, dto.Email, dto.Comment);
        candidate.CallTimeInterval = dto.CallTimeInterval;
        candidate.LinkedInUrl = dto.LinkedInUrl;
        candidate.GitHubUrl = dto.GitHubUrl;
        candidate.PhoneNumber = dto.PhoneNumber;
        _candidateRepository.Update(candidate);
        await _candidateRepository.SaveChangesAsync();
        return candidate.Id;
    }

    private async Task<long> AddAsync(CandidateDto dto)
    {
        var candidate = new Candidate(dto.FirstName, dto.LastName, dto.Email, dto.Comment)
        {
            CallTimeInterval = dto.CallTimeInterval,
            LinkedInUrl = dto.LinkedInUrl,
            GitHubUrl = dto.GitHubUrl,
            PhoneNumber = dto.PhoneNumber
        };
        await _candidateRepository.AddAsync(candidate);
        await _candidateRepository.SaveChangesAsync();
        return candidate.Id;
    }

    private static List<string> EnsureRequiredField(CandidateDto dto)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(dto.FirstName))
        {
            errors.Add("First name cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(dto.LastName))
        {
            errors.Add("Last name cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(dto.Email))
        {
            errors.Add("Email cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(dto.Comment))
        {
            errors.Add("Comment cannot be null or empty");
        }

        return errors;
    }
}