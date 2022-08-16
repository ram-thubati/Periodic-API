using System.ComponentModel.DataAnnotations;

namespace Periodic.Models
{
    public class Category
    {
        public int Id{get; set;}

        [Required]
        public string MainCategory{get; set;}

        public string SubCategory{get; set;}
    }
}