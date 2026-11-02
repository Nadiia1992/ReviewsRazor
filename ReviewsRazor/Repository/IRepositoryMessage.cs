using ReviewsRazor.Models;

namespace ReviewsRazor.Repository
{
    public interface IRepositoryMessage
    {
        Task<IEnumerable<Message>> GetMessageListAsync();
        Task<Message?> GetMessageAsync(int id);
        Task CreateAsync(Message item);
        Task SaveAsync();
    }
}