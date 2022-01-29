using System;

namespace Core.Models
{
    public class UpdateNoteModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime LastModifiedDate { get; set; }     
    }
}
