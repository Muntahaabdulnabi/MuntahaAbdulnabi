namespace WebApi.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Address { get; set; } = null!;
        public string CustomerName => $"{FirstName} {LastName}";
    }
}
