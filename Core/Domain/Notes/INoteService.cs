﻿using Core.Entities;
using Core.Models;

namespace Core.Domain.Notes
{
    public interface INoteService
    {
        public Note GetNote(int id);
        public PaginatedResult<Note> GetAllNotes(string query, string orderBy, string direction);
        public Note CreateNote(CreateNoteModel model);
        public Note UpdateNote(UpdateNoteModel model);
        public void DeleteNote(int noteId);
    }
}
