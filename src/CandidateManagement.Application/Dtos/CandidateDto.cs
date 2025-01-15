﻿namespace CandidateManagement.Application.Dtos;

public class CandidateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? CallTimeInterval { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }
    public string? PhoneNumber { get; set; }
    public string Comment { get; set; }
}