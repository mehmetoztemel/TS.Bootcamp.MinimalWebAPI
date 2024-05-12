namespace TS.Bootcamp.MinimalWebAPI.Models
{
    public class AppUser
    {
        public AppUser()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
    }
}
