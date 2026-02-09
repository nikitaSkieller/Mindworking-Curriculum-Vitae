namespace Mindworking_Curriculum_Vitae.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public string Summary { get; set; } = string.Empty;

        public List<Project> Projects { get; set; } = new();
    }
}
