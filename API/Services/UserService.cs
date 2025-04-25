using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }

    public class UserService : IUserService
    {
        private readonly BackenDbContext _db;

        public UserService(BackenDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }
    }

}
