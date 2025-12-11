using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
