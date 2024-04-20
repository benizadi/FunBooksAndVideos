namespace DataAccess.DTOs;

public class Membership
{
    public int MembershipId { get; set; }
    public decimal MembershipFee { get; set; }
    public MembershipType MembershipType { get; set; }
}