using AutoMapper;
using Lucas.CacauShow.UsersManagement.Contracts.Repositories;
using Lucas.CacauShow.UsersManagement.Contracts.Services;
using Lucas.CacauShow.UsersManagement.Domain.Entities;
using Lucas.CacauShow.UsersManagement.Models.Requests;
using Lucas.CacauShow.UsersManagement.Models.Responses;

namespace Lucas.CacauShow.UsersManagement.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository , IMapper mapper)
        { 
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task DeleteUser(int idUser)
        {
            await _userRepository.DeleteUser(idUser);
        }

        public async Task InsertUser(UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            await _userRepository.InsertUser(user);
        }

        public async Task UpdateUser(int id, UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            await _userRepository.UpdateUser(id, user);
        }
    }
}
