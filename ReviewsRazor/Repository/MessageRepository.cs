using Microsoft.EntityFrameworkCore;
using ReviewsRazor.Models;
using ReviewsRazor.Repository;

namespace ReviewsRazor.Repository
{
    public class MessageRepository(MessageContext context) : IRepositoryMessage
    {
        public async Task<IEnumerable<Message>> GetMessageListAsync()
        {
            return await context.Messages.Include(p => p.User).AsNoTracking().ToListAsync();
        }

        public async Task<Message?> GetMessageAsync(int id)
        {
            return await context.Messages.FindAsync(id);
        }

        public async Task CreateAsync(Message mes)
        {
            await context.Messages.AddAsync(mes);
        }

        public void Update(Message mes)
        {
            context.Messages.Update(mes);
        }

        public async Task DeleteAsync(int id)
        {
            var mess = await context.Messages.FindAsync(id);
            if (mess != null)
            {
                context.Messages.Remove(mess);
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
