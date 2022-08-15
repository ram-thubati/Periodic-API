using Periodic.Models;

namespace Periodic.Data
{
    public interface IPeriodicRepo
    {

        public void CreateAccount(Account new_acc);

        public IEnumerable<Account> GetAllAccountsByUserId(int usr_id);

        public Account GetAccountById(int usr_id, int acc_id);

        public bool UpdateAccount(Account new_acc);

        public void DeleteAccount(Account acc);

        public IEnumerable<Transaction> GetAllTransactionsByuserId(int user_id);
        
        public bool CreateTransaction(Transaction trns);

        public Transaction GetTransactionById(int usr_id, int trns_id);

        public void DeleteTransaction(Transaction trns);

        public bool UpdateTransaction(Transaction trns);

        public IEnumerable<Scheduled> GetAllScheduledByUserId(int usr_id);

        public Scheduled GetScheduledById(int usr_id, int id);

        public bool UpdateSchedule(Scheduled new_sch);

        public bool DeleteSchedule(Scheduled sch);

        public void CreateSchedule(Scheduled new_sch);
    }
}