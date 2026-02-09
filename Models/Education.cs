namespace Mindworking_Curriculum_Vitae.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Summary { get; set; } = "";

        public List<Project> Projects { get; set; } = new();
    }
}
