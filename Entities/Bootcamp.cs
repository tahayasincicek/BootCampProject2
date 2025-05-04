using Core.Enums;

namespace Entities
{
    public class Bootcamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BootcampState BootcampState { get; set; }

        // Navigation
        public ICollection<Application> Applications { get; set; }
    }
}
