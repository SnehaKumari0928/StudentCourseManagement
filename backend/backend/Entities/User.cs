namespace backend.Entities
{
    public class User
    {
         public int UserId { get; set; }
         public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public Student? Student { get; set; }

    }
}
