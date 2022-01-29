using Core.Entities;
using Core.Models;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                CreatedDate = DateTime.Now                
            };

            noteRepository.Create(note);

            return note;
        }

        public IEnumerable<Note> GetNotes(int page, int size, string search = "")
        {
            return Enumerable.Repeat<Note>(new Note()
            {
                NoteId = 1,
                Title = "Titulo de la nota",
                Body = "Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias",
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = DateTime.UtcNow
            }, 12);
        }

        public Note UpdateNote(UpdateNoteModel model)
        {
            var note = this.noteRepository.Get(model.NoteId);

            note.Body = model.Body;
            note.LastModifiedDate = DateTime.Now;
            note.Title = model.Title;

            noteRepository.Update(note);

            return note;            
        }
    }
}
