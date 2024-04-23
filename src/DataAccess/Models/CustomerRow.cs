using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;

public class CustomerRow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long CustomerId { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public bool IsActiveMember { get; set; }
}