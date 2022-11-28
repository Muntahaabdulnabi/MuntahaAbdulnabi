namespace WebApi.Models
{
    public class OrderCreateModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalPrice { get; set; }
        public String CustomerName { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string? StreetNumber { get; set; }
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}