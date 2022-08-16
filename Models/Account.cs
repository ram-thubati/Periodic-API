using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Periodic.Models
{
    public class Account
    {
        public int Id {get; set;}

        [Required]
        public int UserId {get;set;}
        
        [Required]
        [MaxLength(128)]
        public string AccountName{get;set;}

        [Required]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal StartingBalance {get; set;}

        public bool IsCredit{get; set;}

        [Column(TypeName = "decimal(7, 2)")]
        public decimal CreditLimit {get; set;}
    }
}