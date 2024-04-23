using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models.Enums;

namespace DataAccess.Models;

public class ProductRow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public ProductType ProductType { get; set; }
}