using Core.Entities;
using Core.Models;
using Core.Repository;
using System;

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

        public PaginatedResult<Note> GetAllNotes(int page, int size, string search, string orderBy, string direction)
        {            
            var notes = noteRepository.GetAll(page, size, search, orderBy, direction);
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
