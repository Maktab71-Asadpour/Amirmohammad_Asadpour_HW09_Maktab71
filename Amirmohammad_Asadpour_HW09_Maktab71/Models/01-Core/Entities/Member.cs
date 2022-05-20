namespace Amirmohammad_Asadpour_HW09_Maktab71.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Birthday { get; set; }
        public string NationalCode { get; set; }
        public MembershipType MemberType { get; set; }
        public GenderType Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
