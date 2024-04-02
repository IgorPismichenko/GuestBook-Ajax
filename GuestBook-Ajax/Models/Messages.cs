namespace GuestBook_Ajax.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? Date { get; set;}
        public Users? User { get; set; }

        public int UserId { get; set; }
    }
}
