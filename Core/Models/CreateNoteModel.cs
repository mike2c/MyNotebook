using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class CreateNoteModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        public string Body { get; set; }

        [Required(ErrorMessage ="The Topic field is required")]
        [Display(Description = "Topic")]
        public int TopicId { get; set; }
    }
}
