using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlowCaseTracking.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string UserName { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime DataLindjes { get; set; }
        [Required]
        public string Role { get; set; } = "user";

    }
}
