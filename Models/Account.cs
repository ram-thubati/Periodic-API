namespace Periodic.Models
{
    public class Account
    {
        public int Id {get; set;}

        public int UserId {get;set;}
        
        public string AccountName{get;set;}

        public decimal StartingBalance {get; set;}

        public bool IsCredit{get; set;}

        public decimal CreditLimit {get; set;}
    }
}