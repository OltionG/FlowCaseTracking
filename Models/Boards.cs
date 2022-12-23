using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Flow_CaseTracking.Models
{
    public class Boards
    {
        [Key]
        public int Id { get; set; }
        public string Titulli { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }

    }
}
