namespace Periodic.Models
{
    public class Scheduled
    {
        public int Id{get;set;}

        public int UserId{get;set;}

        public string TransactionName{get;set;}

        public int FromAccountId{get;set;}

        public int ToAccountId{get;set;}

        public decimal Amount{get;set;}

        public int CategoryId {get; set;}

        public DateTime StartDate{get;set;}

        public char Frequency{get;set;}

        public int StepSize{get;set;}

        public DateTime EndDate {get; set;}
    }
}