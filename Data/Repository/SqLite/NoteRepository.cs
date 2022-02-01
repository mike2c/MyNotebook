using Core.Entities;
using Core.Repository;
using Data.Context;
using System;
using System.Linq;
using Core.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.SqLite
{
    public class NoteRepository : INoteRepository
    {
        private MyNotebookContext context;

        public NoteRepository(MyNotebookContext context)
        {
            this.context = context;
        }

        public void Create(Note entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = context.Notes.Find(id);
            context.Notes.Remove(entity);
            context.SaveChanges();
        }

        public Note Get(int id)
        {
            var note = context.Notes.Find(id);
            return note;
        }

        public PaginatedResult<Note> GetAll(Expression<Func<Note, bool>> query, Func<IQueryable<Note>, IOrderedQueryable<Note>> orderBy = null)
        {
            var paginationModel = new PaginatedResult<Note>();
            IQueryable<Note> queryable = context.Notes.Include(a => a.Topic).Where(query);

            if(orderBy == null)
            {
                paginationModel.Data = queryable.ToList();
            }
            else
            { 
                paginationModel.Data = orderBy(queryable).ToList();
            }

            paginationModel.Count = queryable.Count();
            return paginationModel;
        }

        public void Update(Note entity)
        {
            context.Notes.Update(entity);
            context.SaveChanges();
        }
    }
}
