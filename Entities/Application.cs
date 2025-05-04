using Core.Enums;

namespace Entities
{
    public class Application
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public ApplicationState ApplicationState { get; set; }

        // Navigation
        public Bootcamp Bootcamp { get; set; }
    }
}
