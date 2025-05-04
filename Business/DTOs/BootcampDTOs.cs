namespace Business.DTOs
{
    public class CreateBootcampRequest
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class BootcampResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
    }
}
