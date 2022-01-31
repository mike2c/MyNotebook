using Core.Entities;
using Core.Models;
using Core.Repository;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repository.SqLite
{
    public class TopicRepository : ITopicRepository
    {
        private MyNotebookContext context;
        public TopicRepository(MyNotebookContext context)
        {
            this.context = context;
        }

        public void Create(Topic entity)
        {
            context.Topics.Add(entity);
            context.SaveChanges();            
        }

        public void Delete(int id)
        {
            var entity = context.Topics.Find(id);
            context.Topics.Remove(entity);
            context.SaveChanges();
        }

        public Topic Get(int id)
        {
            var entity = context.Topics.Find(id);            
            return entity;
        }

        public PaginatedResult<Topic> GetAll(Expression<Func<Topic, bool>> query, Func<IQueryable<Topic>, IOrderedQueryable<Topic>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> List()
        {
            var topics = context.Topics.OrderBy(a => a.TopicName);
            return topics;
        }

        public void Update(Topic entity)
        {            
            context.Topics.Update(entity);
            context.SaveChanges();
        }
    }
}
