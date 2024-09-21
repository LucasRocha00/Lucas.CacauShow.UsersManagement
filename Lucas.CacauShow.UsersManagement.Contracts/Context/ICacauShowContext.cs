using Lucas.CacauShow.UsersManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lucas.CacauShow.UsersManagement.Contracts.Context
{
    public interface ICacauShowContext
    {
        DbSet<User> User { get; }

        //Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
