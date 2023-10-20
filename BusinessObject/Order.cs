using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public int MemberId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate { get; set; }
    public DateTime ShippedDate { get; set; }
    public int Freight { get; set; }
    
    [ForeignKey("MemberId")] 
    public Member Member { get; set; }
}