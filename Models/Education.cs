using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace Mindworking_Curriculum_Vitae.Models
{
    public class Education
    {
        [Key]
        [ID]
        public int Id { get; set; }

        [Required]
        public string School { get; set; } = string.Empty;

        [Required]
        public string Degree { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
