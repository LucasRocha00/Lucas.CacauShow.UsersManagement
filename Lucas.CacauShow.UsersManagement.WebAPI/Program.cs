using Lucas.CacauShow.UsersManagement.Application.Services;
using Lucas.CacauShow.UsersManagement.Contracts.Repositories;
using Lucas.CacauShow.UsersManagement.Contracts.Services;
using Lucas.CacauShow.UsersManagement.Persistence.Context;
using Lucas.CacauShow.UsersManagement.Repository;
using Lucas.CacauShow.UsersManagement.WebAPI.Util;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;
services.AddDbContext<CacauShowContext>();
services.AddAutoMapper(typeof(MappingProfile));
services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
