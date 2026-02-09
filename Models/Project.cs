using System.ComponentModel.DataAnnotations;

namespace Mindworking_Curriculum_Vitae.Models
{
    public class Project
    {
        [Key]
        [ID]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Summary { get; set; } = string.Empty;

        public int? CompanyId { get; set; }

        public Company? Company { get; set; }
    }
}
