using FlowCaseTracking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flow_CaseTracking.Models
{
    public class Boards
    {
        [Key]
        public int Id { get; set; }
        public string Titulli { get; set; }
    }
}