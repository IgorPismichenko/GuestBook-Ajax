using Newtonsoft.Json;

namespace GuestBook_Ajax.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        [JsonIgnore]
        public ICollection<Messages>? Messages { get; set; }
    }
}
