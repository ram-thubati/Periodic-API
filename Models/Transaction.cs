namespace Periodic.Models
{
    public class Transaction
    {
        public int Id{get;set;}

        public int UserId{get; set;}

        public int FromAccountId {get; set;}

        public int ToAccountId{get; set;}

        public decimal Amount{get; set;}

        public char CreatedbyEntityType{get; set;}

        public int CreatedByEntityId{get;set;}

        public DateTime EffectiveDate {get;set;}
    }
}