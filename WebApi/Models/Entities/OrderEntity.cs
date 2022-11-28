namespace WebApi.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalPrice { get; set; }
        public String CustomerName { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string? StreetNumber { get; set; }
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public ICollection<ProductEntity> Products { get; set; }
    }
}
