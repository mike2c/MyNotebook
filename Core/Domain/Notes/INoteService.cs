using Core.Entities;
using Core.Models;

namespace Core.Domain.Notes
{
    public interface INoteService
    {
        public PaginatedResult<Note> GetNotes(int page, int size, string query, string orderBy);
        public Note CreateNote(CreateNoteModel model);
        public Note UpdateNote(UpdateNoteModel model);        
    }
}
