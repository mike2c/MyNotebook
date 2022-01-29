using Core.Entities;
using Core.Models;
using System.Collections.Generic;

namespace Core.Domain.Notes
{
    public interface INoteService
    {
        public IEnumerable<Note> GetNotes(int page, int size, string search = "");
        public Note CreateNote(CreateNoteModel model);
        public Note UpdateNote(UpdateNoteModel model);        
    }
}
