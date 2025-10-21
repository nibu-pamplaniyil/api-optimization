using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IUserRepository
    {
        Task<int> GetUsersCountAsync();
        Task<PagedResult<Users>> GetUsersPageAsync(int pageNumber, int pageSize);
    }
}
