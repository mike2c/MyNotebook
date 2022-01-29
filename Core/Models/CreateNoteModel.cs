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
        public DateTime? CreatedDate { get; set; }     
    }
}
