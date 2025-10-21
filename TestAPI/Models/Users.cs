using System.ComponentModel.DataAnnotations;

namespace TestAPI.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
