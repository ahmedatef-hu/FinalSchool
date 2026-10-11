using SchoolManagement.Data;
using SchoolManagement.Repos.Interfaces;

namespace SchoolManagement.Repos.Impelementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext context;
        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(T item)
        {
            context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
        }

        public async Task<List<T>> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            context.Set<T>().Update(item);
        }
    }
}
