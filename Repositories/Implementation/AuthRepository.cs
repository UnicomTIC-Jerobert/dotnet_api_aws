using ICEDT.API.Data;
using ICEDT.API.Models;
using ICEDT.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ICEDT.API.Repositories.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context) { _context = context; }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<bool> UserExistsAsync(string username, string email)
        {
            return await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower() || u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}