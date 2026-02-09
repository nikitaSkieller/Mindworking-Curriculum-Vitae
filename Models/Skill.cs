using System.ComponentModel.DataAnnotations;

namespace Mindworking_Curriculum_Vitae.Models
{
    public class Skill
    {
        [Key]
        [ID]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Level { get; set; } = string.Empty;
    }
}
