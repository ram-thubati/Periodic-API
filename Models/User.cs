using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Periodic.Models
{
    [Table("Users")]
    public class User
    {
        public int Id{get;set;}

        [Required]
        [MaxLength(32), MinLength(4)]
        public string UserName{get;set;}

        [Required]
        [MaxLength(128), MinLength(4)]
        public string FullName{get;set;}

        public string PasswordHash{get;set;}

        [Required]
        [MaxLength(128)]
        public string Email {get; set;}
        public DateTime DateCreated{get;set;}

        [Required]
        public bool IsEnabled{get;set;} 
    }
}