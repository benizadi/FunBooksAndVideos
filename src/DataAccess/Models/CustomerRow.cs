using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class CustomerRow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }
    public required string FullName { get; set; }
    public required string Address { get; set; }
    public bool IsActiveMember { get; set; }
}