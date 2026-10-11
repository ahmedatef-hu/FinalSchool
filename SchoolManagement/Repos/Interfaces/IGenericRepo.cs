namespace SchoolManagement.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
