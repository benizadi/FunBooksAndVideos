using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Models.Enums;

namespace DataAccess.Models;

public class MembershipRow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long MembershipId { get; set; }
    public MembershipType MembershipType { get; set; }
}