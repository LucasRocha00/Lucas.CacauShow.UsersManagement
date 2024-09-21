using Lucas.CacauShow.UsersManagement.Contracts.Context;
using Lucas.CacauShow.UsersManagement.Contracts.Repositories;
using Lucas.CacauShow.UsersManagement.Domain.Entities;
using Lucas.CacauShow.UsersManagement.Models.Responses;
using Lucas.CacauShow.UsersManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Lucas.CacauShow.UsersManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private CacauShowContext _context;
        public UserRepository(CacauShowContext context)
        {
            _context = context;
        }

        public async Task DeleteUser(int idUser)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == idUser);
            _context.User.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(int id, User user)
        {
            var alreadySavedUser = await GetUser(id);
            alreadySavedUser.Name = user.Name;
            alreadySavedUser.CPF = user.CPF;
            alreadySavedUser.Email = user.Email;
            await _context.SaveChangesAsync();
        }
    }
}
