using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Periodic.Models
{
    public class Scheduled
    {
        public int Id{get;set;}

        [Required]
        public int UserId{get;set;}

        [Required]
        [MaxLength(128)]
        public string TransactionName{get;set;}

        public int FromAccountId{get;set;}

        public int ToAccountId{get;set;}

        [Required]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Amount{get;set;}

        public int CategoryId {get; set;}

        [Required]
        public DateTime StartDate{get;set;}

        [Required]
        public char Frequency{get;set;}
        
        [Required]
        public int StepSize{get;set;}

        [Required]
        public DateTime EndDate {get; set;}
    }
}