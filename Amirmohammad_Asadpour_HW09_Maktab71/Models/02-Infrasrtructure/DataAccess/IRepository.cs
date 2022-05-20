namespace Amirmohammad_Asadpour_HW09_Maktab71.Models._02_Infrasrtructure.DataAccess
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void DeleteById(int id);
        public void Add(T entityItem);
        public void Update(T entityItem);
    }
}
