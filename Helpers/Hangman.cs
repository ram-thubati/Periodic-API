using Periodic.Models;

namespace Periodic.Helpers
{
    public class Hangman
    {
        public Hangman(Scheduled sch)
        {
            this._sch = sch;
        }

        private readonly Scheduled _sch;

        public IEnumerable<Transaction> GetFutureTransactions(Scheduled sch)
        {
            
            var future_trns = new List<Transaction>();

            var all_occurences = TimeMachine.GetAllOccurences(sch.StartDate, sch.Frequency, sch.StepSize, sch.EndDate);

            var future_occurences = all_occurences.Where(x => x >= DateTime.Now);

            foreach (var occ in future_occurences)
            {
                var new_trn = new Transaction();
                new_trn.UserId = sch.UserId;
                new_trn.TransactionName = sch.TransactionName;
                new_trn.FromAccountId = sch.FromAccountId;
                new_trn.ToAccountId = sch.ToAccountId;
                new_trn.Amount = sch.Amount;
                new_trn.EffectiveDate = occ;
                new_trn.CreatedbyEntityType = 'S';
                new_trn.CreatedByEntityId = sch.Id;

                future_trns.Add(new_trn);
            }

            return future_trns;
        }
    }
}