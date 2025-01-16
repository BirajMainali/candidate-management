using CandidateManagement.Application.Configuration;
using CandidateManagement.Infrastructure.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseApplication();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddDbContext<CandidateManagementDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("CandidateManagement.Infrastructure"));
});

builder.Services.AddScoped<DbContext, CandidateManagementDbContext>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetRequiredService<IServiceProvider>();
    using var scope = provider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<CandidateManagementDbContext>();
    dbContext.Database.Migrate();
    app.UseDeveloperExceptionPage();
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.MapControllers();

app.Run();