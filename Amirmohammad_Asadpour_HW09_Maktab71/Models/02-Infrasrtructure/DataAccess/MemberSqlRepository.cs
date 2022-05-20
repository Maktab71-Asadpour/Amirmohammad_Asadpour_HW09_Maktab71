namespace Amirmohammad_Asadpour_HW09_Maktab71.Models._02_Infrasrtructure.DataAccess
{
    public class MemberSqlRepository : IRepository<Member>
    {
        private readonly HW9DbContext _context;

        public MemberSqlRepository()
        {
            _context = new HW9DbContext();
        }

        public void Add(Member entityItem)
        {
            _context.Members.Add(entityItem);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            _context.Members.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Member> GetAll()
        {
            return _context.Members.ToList();
        }

        public Member GetById(int id)
        {
            return _context.Members.ToList().Where(m => m.Id == id).FirstOrDefault();
        }

        public void Update(Member entityItem)
        {
            var member = GetById(entityItem.Id);
            member.RegisterDate = entityItem.RegisterDate;
            member.Gender = entityItem.Gender;
            member.PhoneNumber = entityItem.PhoneNumber;
            member.Birthday = entityItem.Birthday;
            member.MemberType = entityItem.MemberType;
            member.FirstName = entityItem.FirstName;
            member.LastName = entityItem.LastName;
            member.NationalCode = entityItem.NationalCode;
            _context.SaveChanges();
        }
    }
}
