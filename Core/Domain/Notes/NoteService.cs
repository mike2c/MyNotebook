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
            var now = DateTime.Now;

            var note = new Note()
            {                
                Title = model.Title,
                Body = model.Body,
                TopicId = model.TopicId,
                CreatedDate = now,
                LastModifiedDate = now
            };

            noteRepository.Create(note);

            return note;
        }

        public void DeleteNote(int noteId)
        {            
            this.noteRepository.Delete(noteId);
        }

        public PaginatedResult<Note> GetAllNotes(string query, string order)
        {
            Expression<Func<Note, bool>> search = 
                (note) => note.Title.Contains(query) && note.Body.Contains(query);            

            Func<IQueryable<Note>, IOrderedQueryable<Note>> orderBy = 
                (query) =>
                    {
                        order = order.ToLower();
                        switch (order)
                        {
                            case "date":
                                return query.OrderBy(a => a.CreatedDate);
                            case "topic":
                                return query.OrderBy(a => a.Topic.TopicName);
                            default:
                                return query.OrderBy(a => a.Title);
                        }
                    };        

            var notes = this.noteRepository.GetAll(search, orderBy);
            return notes;
        }

        public Note GetNote(int id)
        {
            var note = this.noteRepository.Get(id);
            return note;
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
