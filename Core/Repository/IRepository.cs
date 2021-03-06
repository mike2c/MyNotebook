using Core.Entities;
using Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Repository
{
    public interface IRepository<T> where T : Entity
    {
        public T Get(int id);
        public PaginatedResult<T> GetAll(Pagination pagination);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
