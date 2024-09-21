using Lucas.CacauShow.UsersManagement.Contracts.Context;
using Lucas.CacauShow.UsersManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lucas.CacauShow.UsersManagement.Persistence.Context
{
    public class CacauShowContext : DbContext, ICacauShowContext
    {
        private readonly IConfiguration _configuration;
        public CacauShowContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("CacauShow"));
        }

        public DbSet<User> User { get; set; }
    }
}
