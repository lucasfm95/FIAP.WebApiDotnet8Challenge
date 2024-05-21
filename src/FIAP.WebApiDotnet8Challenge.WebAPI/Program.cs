using FIAP.WebApiDotnet8Challenge.Repositories.Repositories;
using FIAP.WebApiDotnet8Challenge.WebAPI.Middlewares;
using FIAP.WebApiDotnet8Challenge.WebAPI.Configurations;
using FIAP.WebApiDotnet8Challenge.WebAPI.Configurations.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().JsonConfigation();
builder.Services.AddSwagger();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING_POSTGRES") 
                                 ?? throw new Exception("Environment variable CONNECTION_STRING_POSTGRES not found")), ServiceLifetime.Scoped);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHealthcheck();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();