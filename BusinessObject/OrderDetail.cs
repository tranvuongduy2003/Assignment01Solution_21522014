using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject;

[PrimaryKey(nameof(OrderId),nameof(ProductId))]
public class OrderDetail
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }
    
    [ForeignKey("OrderId")] 
    public Order Order { get; set; }
    [ForeignKey("ProductId")] 
    public Product Product { get; set; }
}