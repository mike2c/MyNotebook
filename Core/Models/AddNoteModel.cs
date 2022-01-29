using System;

namespace Core.Models
{
    public class AddNoteModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }     
    }
}
