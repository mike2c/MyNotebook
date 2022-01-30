using Core.Entities;
using Core.Models;
using Core.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Domain.Notes
{
    public class NoteService : INoteService
    {
        private INoteRepository noteRepository;        

        public NoteService(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;     
        }

        public Note CreateNote(CreateNoteModel model)
        {
            var note = new Note()
            {                
                Title = model.Title,
                Body = model.Body,
                TopicId = model.TopicId,
                CreatedDate = DateTime.Now                
            };

            noteRepository.Create(note);

            return note;
        }

        public PaginatedResult<Note> GetNotes(int page, int size, string query, string order)
        {
            Expression<Func<Note, bool>> search = a => a.Title.Contains(query) && a.Body.Contains(query);
            Func<IQueryable<Note>, IOrderedQueryable<Note>> orderBy = null;

            order = order.ToLower();
            switch (order)
            {
                case "":
                    orderBy = query => query.OrderBy(a => a.Title);
                    break;
                case "topic":
                    orderBy = query => query.OrderBy(a => a.Title);
                    break;
                default:
                    orderBy = query => query.OrderBy(a => a.Title);
                    break;
            }

            if (order.ToLower().Equals("title"))
            {
            }

            var notes = this.noteRepository.GetAll(page, size, search);
            return notes;
        }

        public Note UpdateNote(UpdateNoteModel model)
        {
            var note = noteRepository.Get(model.NoteId);            

            note.Body = model.Body;
            note.LastModifiedDate = DateTime.Now;
            note.Title = model.Title;
            note.TopicId = model.TopicId;

            noteRepository.Update(note);

            return note;            
        }
    }
}
