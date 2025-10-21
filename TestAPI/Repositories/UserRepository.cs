using TestAPI.Data;
using TestAPI.Repositories;
using TestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<PagedResult<Users>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            // Skip (pageNumber - 1) * pageSize rows and take pageSize rows
            var items= await _context.Users
                .OrderBy(u => u.CreatedAt) // order is important for consistent paging
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PagedResult<Users>
            {
                Items = items,
                TotalCount = await GetUsersCountAsync()
            };
        }

    }
}
