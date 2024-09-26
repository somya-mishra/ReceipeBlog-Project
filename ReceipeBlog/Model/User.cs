namespace ReceipeBlog.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string HashPassword { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
