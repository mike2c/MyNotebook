using Core.Entities;
using Core.Repository;
using Data.Context;
using System;
using System.Linq;
using Core.Models;
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

        public PaginatedResult<Note> GetAll(int page, int size, string search, string orderBy, string direction)
        {
            var query = context.Notes.Where(a => EF.Functions.Like(a.Title, $"%{search}%") || EF.Functions.Like(a.Body, $"%{search}%"));
            var itemsPerPage = query.Count();
            var data = ApplySorting(query, orderBy, direction).Include(a => a.Topic).Skip((page - 1) * size).Take(size).ToList();

            return new PaginatedResult<Note>(page, size, itemsPerPage, data);
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

        public void Update(Note entity)
        {
            context.Notes.Update(entity);
            context.SaveChanges();
        }

        private IOrderedQueryable<Note> ApplySorting(IQueryable<Note> query, string orderBy, string direction)
        {
            switch (orderBy)
            {
                case "date":
                    return direction.Equals("asc", StringComparison.OrdinalIgnoreCase) ? query.OrderBy(a => a.CreatedDate) : query.OrderByDescending(a => a.CreatedDate);
                case "topic":
                    return direction.Equals("asc", StringComparison.OrdinalIgnoreCase) ? query.OrderBy(a => a.Topic.TopicName) : query.OrderByDescending(a => a.Topic.TopicName);
                default:
                    return direction.Equals("asc", StringComparison.OrdinalIgnoreCase) ? query.OrderBy(a => a.Title) : query.OrderByDescending(a => a.Title);
            }
        }
    }
}
