using Core.Entities;
using System.Collections.Generic;

namespace Core.Repository
{
    public interface IRepository<T> where T : Entity
    {
        public T Get(int id);
        public IEnumerable<T> GetAll(string query = null, int page = 1, int size = 12);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
