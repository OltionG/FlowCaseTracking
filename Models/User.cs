namespace FlowCaseTracking.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataLindjes { get; set; }
        public string Role { get; set; } = "user";

    }
}
