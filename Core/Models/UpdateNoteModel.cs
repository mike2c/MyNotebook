using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class UpdateNoteModel
    {
        [Required]
        public int NoteId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        public string Body { get; set; }

        [Required(ErrorMessage = "The Topic field is required")]
        public int TopicId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
