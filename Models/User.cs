namespace Periodic.Models
{
    public class User
    {
        public int Id{get;set;}

        public string UserName{get;set;}

        public string Fullname{get;set;}

        public string PasswordHash{get;set;}

        public string Email {get; set;}

        public DateTime DateCreated{get;set;}

        public bool IsEnabled{get;set;} 
    }
}