using FIAP.WebApiDotnet8Challenge.WebAPI.Middlewares;
using FIAP.WebApiDotnet8Challenge.WebAPI.Configurations;
using FIAP.WebApiDotnet8Challenge.WebAPI.Configurations.IoC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().JsonConfigation();
builder.Services.AddSwagger();
builder.Services.AddServices();
builder.Services.AddRepositories();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();