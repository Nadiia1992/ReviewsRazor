using ReviewsRazor.Models;
using System.ComponentModel.DataAnnotations;


namespace ReviewsRazor.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? Salt { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
