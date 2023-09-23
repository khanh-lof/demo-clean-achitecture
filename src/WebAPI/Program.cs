using CabinetManagement.Application.Common.Interfaces;
using CabinetManagement.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
// Add services to the container.
builder.Services.AddApplicationServices();
builder.Configuration.AddUserSecrets<Program>();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
