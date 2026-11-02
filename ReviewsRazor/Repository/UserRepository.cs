using Microsoft.EntityFrameworkCore;
using ReviewsRazor.Models;
using ReviewsRazor.Repository;
using System.Security.Cryptography;
using System.Text;

namespace ReviewsRazor.Repository
{
    public class UserRepository(MessageContext context) : IRepositoryUser
    {
        public async Task<IEnumerable<Users>> GetUserListAsync()
        {

            return await context.User.AsNoTracking().ToListAsync();
        }

        public async Task<Users?> GetUserAsync(int id)
        {
            return await context.User.FindAsync(id);
        }

        public async Task CreateAsync(Users us)
        {
            await context.User.AddAsync(us);
        }

        public async Task<Users?> GetUserByLoginAsync(string logon)
        {
            return await context.User.FirstOrDefaultAsync(a => a.Login == logon);
        }

        public async Task<bool> UserExistsAsync(string login)
        {
            return await context.User.AnyAsync(u => u.Login == login);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}