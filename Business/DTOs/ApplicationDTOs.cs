namespace Business.DTOs
{
    public class CreateApplicationRequest
    {
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
    }

    public class ApplicationResponse
    {
        public int Id { get; set; }
        public string State { get; set; } = string.Empty;
    }
}
