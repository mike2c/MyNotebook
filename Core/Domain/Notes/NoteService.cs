using Core.Entities;
using Core.Models;
using Core.Repository;
using System;
using System.Linq;

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

        public PaginatedResult<Note> GetAllNotes(string search, string orderBy, string direction)
        {
            Func<IQueryable<Note>, IOrderedQueryable<Note>> sortingBy = GetSortingFunction(orderBy, direction);
            var notes = noteRepository.GetAll(search, sortingBy);
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

        private Func<IQueryable<Note>, IOrderedQueryable<Note>> GetSortingFunction(string orderBy, string direction)
        {
            Func<IQueryable<Note>, IOrderedQueryable<Note>> sortingFunction = 
                (query) =>
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
                };

            return sortingFunction;
        }
    }
}
