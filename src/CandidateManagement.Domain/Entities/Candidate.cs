namespace CandidateManagement.Domain.Entities;

public class Candidate : IEntity
{
    public long Id { get; set; }
    public string FirstName { get; protected set; } = null!;
    public string LastName { get; protected set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Email { get; protected set; } = null!;
    public string? CallTimeInterval { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }
    public string Comment { get; protected set; } = null!;

    protected Candidate()
    {
    }

    public Candidate(string firstName, string lastName, string email, string comment)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Comment = comment;
    }


    public void Update(string firstName, string lastName, string email, string comment)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Comment = comment;
    }

   
}