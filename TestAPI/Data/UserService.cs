using Microsoft.EntityFrameworkCore;
using TestAPI.Models;
using TestAPI.Repositories;

namespace TestAPI.Data
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResult<Users>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            return await _userRepository.GetUsersPageAsync(pageNumber,  pageSize);
        }
        
        public async Task<int> GetUsersCountAsync()
        {
            return await _userRepository.GetUsersCountAsync();
        }

    }
}
