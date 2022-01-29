using Core.Entities;
using Core.Repository;
using Data.Context;
using System;
using System.Collections.Generic;

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
            this.context.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Note Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetAll(string query = null, int page = 1, int size = 12)
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
        {
            throw new NotImplementedException();
        }
    }
}
