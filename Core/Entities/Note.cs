using System;

namespace Core.Entities
{
    public class Note : Entity
    {
        public int NoteId { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
