using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Periodic.Models
{
    public class Transaction
    {
        public int Id{get;set;}

        [Required]
        public int UserId{get;set;}

        [Required]
        [MaxLength(128)]
        public string TransactionName{get;set;}

        public int FromAccountId {get; set;}

        public int ToAccountId{get; set;}

        [Required]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Amount{get; set;}

        [Required]
        public char CreatedbyEntityType{get; set;}

        [Required]
        public int CreatedByEntityId{get;set;}

        [Required]
        public DateTime EffectiveDate {get;set;}
    }
}