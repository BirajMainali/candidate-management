using AutoFixture;
using CandidateManagement.Application.Dtos;
using CandidateManagement.Application.Services;
using CandidateManagement.Domain.Entities;
using CandidateManagement.Infrastructure.Repositories.Candidates;
using NSubstitute;
using Shouldly;

namespace CandidateManagement.Application.Tests
{
    public class CandidateServiceTests
    {
        private ICandidateRepository _candidateRepository;
        private CandidateService _candidateService;
        private Fixture _fixture = new();

        public CandidateServiceTests()
        {
            _candidateRepository = Substitute.For<ICandidateRepository>();
            _candidateService = new CandidateService(_candidateRepository);
        }

        [Fact]
        public async Task AddOrUpdateAsync_Should_Return_Errors_When_Required_Fields_Are_Missing()
        {
            var candidateDto = _fixture.Build<CandidateDto>()
                .Without(c => c.FirstName)
                .Without(c => c.LastName)
                .Without(c => c.Email)
                .Without(c => c.Comment)
                .Create();

            var (id, errors) = await _candidateService.AddOrUpdateAsync(candidateDto);

            id.ShouldBeNull();
            errors.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task AddOrUpdateAsync_Should_Add_New_Candidate_When_Not_Exists()
        {
            var candidateDto = _fixture.Create<CandidateDto>();

            _candidateRepository.FindByEmailAsync(candidateDto.Email).Returns((Candidate)null);

            var (id, errors) = await _candidateService.AddOrUpdateAsync(candidateDto);

            errors.ShouldBeEmpty();

            await _candidateRepository.Received(1).AddAsync(Arg.Is<Candidate>(c =>
                c.FirstName == candidateDto.FirstName &&
                c.LastName == candidateDto.LastName &&
                c.Email == candidateDto.Email &&
                c.Comment == candidateDto.Comment &&
                c.CallTimeInterval == candidateDto.CallTimeInterval &&
                c.LinkedInUrl == candidateDto.LinkedInUrl &&
                c.GitHubUrl == candidateDto.GitHubUrl &&
                c.PhoneNumber == candidateDto.PhoneNumber
            ));
            await _candidateRepository.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task AddOrUpdateAsync_Should_Update_Existing_Candidate()
        {
            var candidateDto = _fixture.Create<CandidateDto>();

            var existingCandidate = new Candidate(candidateDto.FirstName, candidateDto.LastName, candidateDto.Email,
                candidateDto.Comment)
            {
                CallTimeInterval = candidateDto.CallTimeInterval,
                LinkedInUrl = candidateDto.LinkedInUrl,
                GitHubUrl = candidateDto.GitHubUrl,
                PhoneNumber = candidateDto.PhoneNumber
            };

            _candidateRepository.FindByEmailAsync(candidateDto.Email).Returns(existingCandidate);

            var (id, errors) = await _candidateService.AddOrUpdateAsync(candidateDto);

            errors.ShouldBeEmpty();
            id.ShouldBe(existingCandidate.Id);
            _candidateRepository.Received(1).Update(Arg.Is<Candidate>(c =>
                c.FirstName == candidateDto.FirstName &&
                c.LastName == candidateDto.LastName &&
                c.Email == candidateDto.Email &&
                c.Comment == candidateDto.Comment &&
                c.CallTimeInterval == candidateDto.CallTimeInterval &&
                c.LinkedInUrl == candidateDto.LinkedInUrl &&
                c.GitHubUrl == candidateDto.GitHubUrl &&
                c.PhoneNumber == candidateDto.PhoneNumber
            ));
            await _candidateRepository.Received(1).SaveChangesAsync();
        }
    }
}