using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Flow_CaseTracking.Models
{
    public class Lists
    {
        [Key]
        public int Id { get; set; }
        public string Titulli { get; set; }
        public int BoardId { get; set; }
        public string Board { get; set; }

    }
}
