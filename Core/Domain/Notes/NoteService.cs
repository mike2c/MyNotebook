using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Notes
{
    public class NoteService : INoteService
    {
        public Note CreateNote(AddNoteModel model)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
