
using API.Data;
using API.InputDto;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<bool> CreateAdminUser(string email, string password, string fName, string lName);
        Task<User> LoginAsync(LoginDto dto);
    }

    public class AuthService: IAuthService
    {
        private readonly BackendDbContext _dbContext;

        public AuthService(BackendDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (await _dbContext.Users.AnyAsync(u => u.email == dto.email))
                return false;

            CreatePasswordHash(dto.password, out byte[] hash, out byte[] salt);

            var user = new User
            {
                email = dto.email,
                passwordHash = hash,
                passwordSalt = salt,
                firstName = dto.firstName,
                lastName = dto.lastName
            };

            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> CreateAdminUser(string email, string password, string fName, string lName)
        {
            if (await _dbContext.Users.AnyAsync(u => u.email == email))
                return false;

            CreatePasswordHash(password, out byte[] hash, out byte[] salt);

            var user = new User
            {
                email = email,
                passwordHash = hash,
                passwordSalt = salt,
                firstName = fName,
                lastName = lName,
                role = 2
            };

            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }

        public async Task<User> LoginAsync(LoginDto dto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.email == dto.email);
            if (user == null || !VerifyPasswordHash(dto.password, user.passwordHash, user.passwordSalt))
                return null;

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(salt);
            var generatedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return generatedHash.SequenceEqual(hash);
        }
    }
}