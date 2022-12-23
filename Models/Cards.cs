using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Flow_CaseTracking.Models
{
    public class Cards
    {
        [Key]
        public int Id { get; set; }
        public string Titulli { get; set; }
        public int ListId { get; set; }
        public string List { get; set; }
        public string Description { get; set; }
    }
}
