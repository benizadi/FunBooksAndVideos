using DataAccess.DTOs.Enums;

namespace DataAccess.DTOs;

public class MembershipRow
{
    public int MembershipId { get; set; }
    public decimal MembershipFee { get; set; }
    public MembershipType MembershipType { get; set; }
}