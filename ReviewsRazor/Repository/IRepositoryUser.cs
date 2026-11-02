using ReviewsRazor.Models;

namespace ReviewsRazor.Repository
{
    public interface IRepositoryUser
    {
        Task<IEnumerable<Users>> GetUserListAsync();
        Task<Users?> GetUserAsync(int id);
        Task CreateAsync(Users item);
        Task<Users?> GetUserByLoginAsync(string logon);
        Task<bool> UserExistsAsync(string login);
        Task SaveAsync();
    }
}
