using CandidateManagement.Application.Dtos;
using CandidateManagement.Application.Services;
using CandidateManagement.Application.Services.Interfaces;
using CandidateManagement.Contracts.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidateController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidateController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    [HttpPost("add-or-update")]
    public async Task<IActionResult> AddOrUpdateAsync([FromBody] CandidateRequest request)
    {
        try
        {
            var dto = new CandidateDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Comment = request.Comment,
                CallTimeInterval = request.CallTimeInterval,
                LinkedInUrl = request.LinkedInUrl,
                GitHubUrl = request.GitHubUrl,
                PhoneNumber = request.PhoneNumber
            };

            var (id, errors) = await _candidateService.AddOrUpdateAsync(dto);
            return errors.Count != 0 ? BadRequest(errors) : Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}