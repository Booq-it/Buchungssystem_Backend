using API.Data;
using API.InputDto;
using API.Models;
using API.OutputDto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserById(int id);
    }

    public class UserService : IUserService
    {
        private readonly BackendDbContext _db;

        public UserService(BackendDbContext db)
        {
            _db = db;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _db.Users
                .Include(b => b.Bookings)
                .ToListAsync();

            var userDtos = new List<UserDto>();
            
            foreach (var user in users)
            {
                userDtos.Add(new UserDto
                {
                    Id = user.Id,
                    email = user.email,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    role = user.role, 
                    bookingIds = user.Bookings.Select(s => s.Id).ToList()
                });
            }

            return userDtos;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _db.Users
                .Include(b => b.Bookings)
                .FirstOrDefaultAsync(u => u.Id == id);

            return new UserDto
            {
                Id = user.Id,
                email = user.email,
                firstName = user.firstName,
                lastName = user.lastName,
                role = user.role,
                bookingIds = user.Bookings.Select(s => s.Id).ToList()
            };
        }
    }

}
