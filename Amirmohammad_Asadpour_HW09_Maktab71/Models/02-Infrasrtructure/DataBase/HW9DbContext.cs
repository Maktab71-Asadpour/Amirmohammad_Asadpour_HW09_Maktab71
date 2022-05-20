using Microsoft.EntityFrameworkCore;

namespace Amirmohammad_Asadpour_HW09_Maktab71.Models
{
    public class HW9DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SQL2019;Database=HW9_DB;User Id=sa;Password=1234a1234;");
        }

        public DbSet<Member> Members { get; set; }
    }
}
