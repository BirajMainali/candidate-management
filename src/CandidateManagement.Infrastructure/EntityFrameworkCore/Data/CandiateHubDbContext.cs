using CandidateManagement.Domain;
using CandidateManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement.Infrastructure.EntityFrameworkCore.Data;

public class CandidateManagementDbContext : DbContext
{
    public CandidateManagementDbContext(DbContextOptions<CandidateManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Candidate>(b =>
        {
            b.Property(c => c.FirstName).HasMaxLength(100).IsRequired();
            b.Property(c => c.LastName).HasMaxLength(100).IsRequired();
            b.Property(c => c.PhoneNumber).HasMaxLength(20);
            b.Property(c => c.Email).IsRequired().HasMaxLength(100);
            b.HasIndex(c => c.Email).IsUnique();
            b.Property(c => c.CallTimeInterval).HasMaxLength(100);
            b.Property(c => c.LinkedInUrl).HasMaxLength(200);
            b.Property(c => c.GitHubUrl).HasMaxLength(200);
            b.Property(c => c.Comment).IsRequired();
        });
    }
}