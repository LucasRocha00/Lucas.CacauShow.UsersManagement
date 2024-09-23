using Lucas.CacauShow.UsersManagement.Models.Requests;
using Lucas.CacauShow.UsersManagement.Models.Responses;

namespace Lucas.CacauShow.UsersManagement.Contracts.Services
{
    public interface IUserService
    {
        Task DeleteUser(int idUser);
        Task<bool> DoLogon(string userName, string password);
        Task<IEnumerable<UserResponse>> GetAllUsers();
        Task<UserResponse> GetUser(int id);
        Task InsertUser(UserRequest user);
        Task UpdateUser(int id, UserRequest user);
    }
}
