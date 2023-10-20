using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string  ProductName { get; set; }
    public double Weight { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}
