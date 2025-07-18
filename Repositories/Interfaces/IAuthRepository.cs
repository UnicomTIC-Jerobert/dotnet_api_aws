using ICEDT.API.Models;

namespace ICEDT.API.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<bool> UserExistsAsync(string username, string email);
        Task<User> RegisterUserAsync(User user);
    }
}