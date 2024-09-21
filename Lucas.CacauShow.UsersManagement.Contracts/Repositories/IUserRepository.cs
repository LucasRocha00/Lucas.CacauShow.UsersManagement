using Lucas.CacauShow.UsersManagement.Domain.Entities;
using Lucas.CacauShow.UsersManagement.Models.Requests;
using Lucas.CacauShow.UsersManagement.Models.Responses;

namespace Lucas.CacauShow.UsersManagement.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task DeleteUser(int idUser);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task InsertUser(User user);
        Task UpdateUser(int id, User user);
    }
}
